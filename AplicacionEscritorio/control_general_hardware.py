import tkinter as tk
from tkinter import ttk
from tkinter import messagebox
import requests
from datetime import datetime

class ControlGeneralHardware(tk.Frame):
    def __init__(self, master=None):
        super().__init__(master)
        self.master = master
        self.pack(expand=True, fill="both")

        # Obtener las dimensiones de la pantalla y configurar la geometría de la ventana
        ancho_pantalla = master.winfo_screenwidth()
        alto_pantalla = master.winfo_screenheight()
        self.master.geometry(f"{ancho_pantalla}x{alto_pantalla}")

        # Crear el frame para la tabla y la barra de desplazamiento
        frame_tabla = tk.Frame(self)
        frame_tabla.pack(expand=True, fill="both")

        # Crear la tabla con columnas
        self.tree = ttk.Treeview(frame_tabla, columns=(
            "ID", "Cantidad", "Marca", "No. Serie", "Descripción", "Condición",
            "Observación Pre", "Observación Post", "Fecha Pre", "Fecha Post",
            "Nombre Solicitante", "Correo Solicitante", "Área Solicitante", "Tipo Solicitante", "Tipo Fallo", "Estatus"
        ), show="headings")

        # Configurar el ancho de las columnas
        column_widths = {
            "ID": 50,
            "Cantidad": 80,
            "Marca": 100,
            "No. Serie": 100,
            "Descripción": 150,
            "Condición": 150,
            "Observación Pre": 150,
            "Observación Post": 150,
            "Fecha Pre": 150,
            "Fecha Post": 150,
            "Nombre Solicitante": 150,
            "Correo Solicitante": 200,
            "Área Solicitante": 250,
            "Tipo Solicitante": 150,
            "Tipo Fallo": 100,
            "Estatus": 100
        }
        for col, width in column_widths.items():
            self.tree.heading(col, text=col, anchor="w")
            self.tree.column(col, width=width, anchor='w')

        self.tree.pack(side="left", expand=True, fill="both")

        # Crear la barra de desplazamiento horizontal
        hsb = ttk.Scrollbar(frame_tabla, orient="horizontal", command=self.tree.xview)
        hsb.pack(side="bottom", fill="x")
        self.tree.configure(xscrollcommand=hsb.set)

        # Botones de control
        self.update_button = tk.Button(self, text="Actualizar", command=self.update_table)
        self.update_button.pack()
        self.edit_button = tk.Button(self, text="Editar", command=self.editar_formulario)
        self.edit_button.pack()

        # Cargar datos al iniciar la aplicación
        self.update_table()

    def get_data(self):
        try:
            url = "http://localhost:5118/api/formularioshardware"
            response = requests.get(url)
            response.raise_for_status()
            return response.json()
        except requests.RequestException as e:
            messagebox.showerror("Error", f"No se pudo obtener los datos: {e}")
            return []

    def editar_formulario(self):
        selected_item = self.tree.selection()
        if selected_item:
            id_formulario = self.tree.item(selected_item[0])["values"][0]
            formulario_data = self.get_formulario_data(id_formulario)
            if formulario_data:
                self.mostrar_ventana_edicion(formulario_data)
            else:
                messagebox.showerror("Error", "No se pudo obtener los datos del formulario")
        else:
            messagebox.showwarning("Advertencia", "Por favor, seleccione un formulario para editar")

    def get_formulario_data(self, id_formulario):
        try:
            url = f"http://localhost:5118/api/formularioshardware/{id_formulario}"
            response = requests.get(url)
            response.raise_for_status()
            return response.json()
        except requests.RequestException as e:
            messagebox.showerror("Error", f"No se pudo obtener los datos del formulario: {e}")
            return None

    def update_table(self):
        data = self.get_data()
        for row in self.tree.get_children():
            self.tree.delete(row)
        for item in data:
            estatus = item["estatusHard"]
            # Asignar etiqueta según el estatus
            if estatus:
                tag = "verde"
            else:
                tag = "rojo"
            self.tree.insert("", "end", values=(
                item["idFormularioHardware"],
                item["cantidad"],
                item["marca"],
                item["noSerie"],
                item["descripcionHard"],
                item["condicion"],
                item["observacionPre"],
                item["observacionPost"],
                item["fechaPreHard"],
                item["fechaPostHard"],
                item["solicitante"]["nombreSolicitanteHard"],
                item["solicitante"]["correoHard"],  # Nuevo campo
                item["solicitante"]["areaHard"],    # Nuevo campo
                item["solicitante"]["tipoSolicitanteHard"],
                item["solicitante"]["tipoFalloHard"],
                item["estatusHard"]
            ), tags=(tag,))

        # Configurar el color de fondo de las filas según la etiqueta
        self.tree.tag_configure("verde", background="light green")
        self.tree.tag_configure("rojo", background="salmon")

    def guardar_cambios(self, id_formulario, cantidad, marca, no_serie, descripcion, condicion, observacion_pre, observacion_post, fecha_pre, fecha_post, estatus, ventana_edicion):
        data = {
            "cantidad": cantidad,
            "marca": marca,
            "noSerie": no_serie,
            "descripcionHard": descripcion,
            "condicion": condicion,
            "observacionPre": observacion_pre,
            "observacionPost": observacion_post,
            "fechaPreHard": fecha_pre,
            "fechaPostHard": fecha_post,
            "estatusHard": estatus,
            "idSolicitanteHard": id_formulario,
            "idOperador": 1
        }
        try:
            url = f"http://localhost:5118/api/formularioshardware/{id_formulario}"
            response = requests.put(url, json=data)
            response.raise_for_status()
            messagebox.showinfo("Éxito", "Los cambios se guardaron correctamente")
            self.update_table()
            ventana_edicion.destroy()  # Cierra la ventana emergente después de guardar los cambios
        except requests.RequestException as e:
            messagebox.showerror("Error", f"No se pudieron guardar los cambios: {e}")

    def mostrar_ventana_edicion(self, formulario_data):
        ventana_edicion = tk.Toplevel(self.master)
        ventana_edicion.title("Editar Formulario de Hardware")

        tk.Label(ventana_edicion, text="Cantidad:").grid(row=0, column=0, padx=5, pady=5)
        cantidad_entry = tk.Entry(ventana_edicion, width=50)
        cantidad_entry.grid(row=0, column=1, columnspan=2, padx=5, pady=5)
        cantidad_entry.insert(0, formulario_data["cantidad"])

        tk.Label(ventana_edicion, text="Marca:").grid(row=1, column=0, padx=5, pady=5)
        marca_entry = tk.Entry(ventana_edicion, width=50)
        marca_entry.grid(row=1, column=1, columnspan=2, padx=5, pady=5)
        marca_entry.insert(0, formulario_data["marca"])

        tk.Label(ventana_edicion, text="No. Serie:").grid(row=2, column=0, padx=5, pady=5)
        no_serie_entry = tk.Entry(ventana_edicion, width=50)
        no_serie_entry.grid(row=2, column=1, columnspan=2, padx=5, pady=5)
        no_serie_entry.insert(0, formulario_data["noSerie"])

        tk.Label(ventana_edicion, text="Descripción:").grid(row=3, column=0, padx=5, pady=5)
        descripcion_entry = tk.Entry(ventana_edicion, width=50)
        descripcion_entry.grid(row=3, column=1, columnspan=2, padx=5, pady=5)
        descripcion_entry.insert(0, formulario_data["descripcionHard"])

        tk.Label(ventana_edicion, text="Condición:").grid(row=4, column=0, padx=5, pady=5)
        condicion_entry = tk.Entry(ventana_edicion, width=50)
        condicion_entry.grid(row=4, column=1, columnspan=2, padx=5, pady=5)
        condicion_entry.insert(0, formulario_data["condicion"])

        tk.Label(ventana_edicion, text="Observación Pre:").grid(row=5, column=0, padx=5, pady=5)
        observacion_pre_entry = tk.Entry(ventana_edicion, width=50)
        observacion_pre_entry.grid(row=5, column=1, columnspan=2, padx=5, pady=5)
        observacion_pre_entry.insert(0, formulario_data["observacionPre"])

        tk.Label(ventana_edicion, text="Observación Post:").grid(row=6, column=0, padx=5, pady=5)
        observacion_post_entry = tk.Entry(ventana_edicion, width=50)
        observacion_post_entry.grid(row=6, column=1, columnspan=2, padx=5, pady=5)
        observacion_post_entry.insert(0, formulario_data["observacionPost"])

        tk.Label(ventana_edicion, text="Fecha Pre:").grid(row=7, column=0, padx=5, pady=5)
        fecha_pre_entry = tk.Entry(ventana_edicion, width=50)
        fecha_pre_entry.grid(row=7, column=1, columnspan=2, padx=5, pady=5)
        fecha_pre_entry.insert(0, formulario_data["fechaPreHard"])

        tk.Label(ventana_edicion, text="Fecha Post:").grid(row=8, column=0, padx=5, pady=5)
        fecha_post_entry = tk.Entry(ventana_edicion, width=50)
        fecha_post_entry.grid(row=8, column=1, columnspan=2, padx=5, pady=5)
        fecha_post_entry.insert(0, formulario_data["fechaPostHard"])

        tk.Label(ventana_edicion, text="Estatus:").grid(row=9, column=0, padx=5, pady=5)
        estatus_var = tk.BooleanVar(value=formulario_data["estatusHard"])
        estatus_check = tk.Checkbutton(ventana_edicion, variable=estatus_var)
        estatus_check.grid(row=9, column=1, padx=5, pady=5)

        guardar_button = tk.Button(ventana_edicion, text="Guardar Cambios",
                                   command=lambda: self.guardar_cambios(
                                       formulario_data["idFormularioHardware"],
                                       cantidad_entry.get(),
                                       marca_entry.get(),
                                       no_serie_entry.get(),
                                       descripcion_entry.get(),
                                       condicion_entry.get(),
                                       observacion_pre_entry.get(),
                                       observacion_post_entry.get(),
                                       fecha_pre_entry.get(),
                                       fecha_post_entry.get(),
                                       estatus_var.get(),
                                       ventana_edicion))  # Pasa la instancia de la ventana como argumento
        guardar_button.grid(row=10, column=1, padx=5, pady=5)


if __name__ == "__main__":
    root = tk.Tk()
    app = ControlGeneralHardware(root)
    root.mainloop()
