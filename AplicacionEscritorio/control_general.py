import tkinter as tk
from tkinter import ttk
from tkinter import messagebox
import requests
import os
import base64

class ControlGeneralApi(tk.Frame):
    def __init__(self, master=None):
        super().__init__(master)
        self.master = master
        self.pack(expand=True, fill="both")
        ancho_pantalla = master.winfo_screenwidth()
        alto_pantalla = master.winfo_screenheight()

        self.master.geometry(f"{ancho_pantalla}x{alto_pantalla}")

        self.pack(expand=True, fill="both")
        self.tree = ttk.Treeview(self, columns=(
            "ID",
            "Descripción",
            "Nombre Solicitante",
            "Correo Solicitante",
            "Área Solicitante",
            "Tipo Solicitante",
            "Tipo Fallo",
            "Fecha Pre",
            "Fecha Post",
            "Estatus"
        ), show="headings")
        self.tree.heading("ID", text="ID", anchor="w")
        self.tree.heading("Descripción", text="Descripción", anchor="w")
        self.tree.heading("Nombre Solicitante", text="Nombre Solicitante", anchor="w")
        self.tree.heading("Correo Solicitante", text="Correo Solicitante", anchor="w")
        self.tree.heading("Área Solicitante", text="Área Solicitante", anchor="w")
        self.tree.heading("Tipo Solicitante", text="Tipo Solicitante", anchor="w")
        self.tree.heading("Tipo Fallo", text="Tipo Fallo", anchor="w")
        self.tree.heading("Fecha Pre", text="Fecha Pre", anchor="w")
        self.tree.heading("Fecha Post", text="Fecha Post", anchor="w")
        self.tree.heading("Estatus", text="Estatus", anchor="w")
        self.tree.pack(expand=True, fill="both")

        self.update_button = tk.Button(self, text="Actualizar", command=self.update_table)
        self.update_button.pack()

        self.edit_button = tk.Button(self, text="Editar", command=self.editar_registro)
        self.edit_button.pack()

        self.download_button = tk.Button(self, text="Descargar Imágenes", command=self.descargar_imagenes)
        self.download_button.pack()

        self.update_table()
        self.ventana_edicion = None  # Inicializamos la variable de la ventana de edición

    def get_data(self):
        url = "http://localhost:5118/api/formulariossoftware"
        response = requests.get(url)
        data = response.json()
        return data

    def update_table(self):
        data = self.get_data()
        for row in self.tree.get_children():
            self.tree.delete(row)
        for item in data:
            estatus = item["estatus"]
            tag = "verde" if estatus else "rojo"
            self.tree.insert("", "end", values=(
                item["idFormularioSoftware"],
                item["descripcion"],
                item["solicitante"]["nombreSolicitanteSoft"],
                item["solicitante"]["correoSoft"],
                item["solicitante"]["areaSoft"],
                item["solicitante"]["tipoSolicitanteSoft"],
                item["solicitante"]["tipoFalloSoft"],
                item["fechaPre"],
                item["fechaPost"],
                estatus
            ), tags=(tag,))

        # Configurar el color de fondo de las filas según la etiqueta
        self.tree.tag_configure("verde", background="light green")
        self.tree.tag_configure("rojo", background="salmon")

    def editar_registro(self):
        selected_item = self.tree.selection()
        if selected_item:
            id_formulario = self.tree.item(selected_item[0])["values"][0]
            formulario_data = self.get_formulario_data(id_formulario)
            if formulario_data:
                self.mostrar_ventana_edicion(formulario_data)
            else:
                messagebox.showerror("Error", "No se pudieron obtener los datos del formulario")
        else:
            messagebox.showwarning("Advertencia", "Por favor, seleccione un formulario para editar")

    def get_formulario_data(self, id_formulario):
        url = f"http://localhost:5118/api/formulariossoftware/{id_formulario}"
        response = requests.get(url)
        if response.status_code == 200:
            return response.json()
        else:
            return None

    def mostrar_ventana_edicion(self, formulario_data):
        self.ventana_edicion = tk.Toplevel(self.master)
        self.ventana_edicion.title("Editar Formulario de Software")

        tk.Label(self.ventana_edicion, text="Descripción:").grid(row=0, column=0, padx=5, pady=5)
        descripcion_entry = tk.Entry(self.ventana_edicion, width=50)
        descripcion_entry.grid(row=0, column=1, columnspan=2, padx=5, pady=5)
        descripcion_entry.insert(0, formulario_data["descripcion"])

        tk.Label(self.ventana_edicion, text="Fecha Pre:").grid(row=1, column=0, padx=5, pady=5)
        fecha_pre_entry = tk.Entry(self.ventana_edicion, width=50)
        fecha_pre_entry.grid(row=1, column=1, columnspan=2, padx=5, pady=5)
        fecha_pre_entry.insert(0, formulario_data["fechaPre"])

        tk.Label(self.ventana_edicion, text="Fecha Post:").grid(row=2, column=0, padx=5, pady=5)
        fecha_post_entry = tk.Entry(self.ventana_edicion, width=50)
        fecha_post_entry.grid(row=2, column=1, columnspan=2, padx=5, pady=5)
        fecha_post_entry.insert(0, formulario_data["fechaPost"])

        tk.Label(self.ventana_edicion, text="Estatus:").grid(row=3, column=0, padx=5, pady=5)
        estatus_var = tk.BooleanVar(value=formulario_data["estatus"])
        estatus_check = tk.Checkbutton(self.ventana_edicion, variable=estatus_var)
        estatus_check.grid(row=3, column=1, padx=5, pady=5)

        guardar_button = tk.Button(self.ventana_edicion, text="Guardar Cambios",
                                   command=lambda: self.guardar_cambios(formulario_data["idFormularioSoftware"],
                                                                       descripcion_entry.get(),
                                                                       fecha_pre_entry.get(),
                                                                       fecha_post_entry.get(),
                                                                       estatus_var.get(),
                                                                       formulario_data["solicitante"]["correoSoft"]))
        guardar_button.grid(row=4, column=1, padx=5, pady=5)

    def guardar_cambios(self, id_formulario, descripcion, fecha_pre, fecha_post, estatus, correo_soft):
        data = {
            "descripcion": descripcion,
            "fechaPre": fecha_pre,
            "fechaPost": fecha_post,
            "estatus": estatus,
            "idSolicitanteSoft": id_formulario,  
            "idOperador": 1 
        }
        url = f"http://localhost:5118/api/formulariossoftware/{id_formulario}"
        response = requests.put(url, json=data)
        if response.status_code == 200:
            messagebox.showinfo("Éxito", "Los cambios se guardaron correctamente")
            self.update_table()  
            self.ventana_edicion.destroy()  # Cerrar la ventana de edición después de guardar cambios
        else:
            messagebox.showerror("Error", "No se pudieron guardar los cambios")

    def descargar_imagenes(self):
        # Instanciamos la clase DescargarImagenes y llamamos al método descargar_imagenes
        downloader = DescargarImagenes(self.master)
        downloader.descargar_imagenes()
        messagebox.showinfo("Éxito", "Las imagenes se guardaron corectamente")

class DescargarImagenes:
    def __init__(self, ventana):
        self.ventana = ventana

    def descargar_imagenes(self):
        # Ruta de la carpeta donde se guardarán las imágenes
        path = r'C:\Users\osval\Desktop\GitProyect\ProyectoResidencias\PaginaWeb\imagenesformulario'

        # Eliminar todos los archivos de la carpeta antes de proceder
        for filename in os.listdir(path):
            filepath = os.path.join(path, filename)
            try:
                os.remove(filepath)
                print(f'Archivo {filename} eliminado')
            except Exception as e:
                print(f'Error al eliminar el archivo {filename}: {e}')

        # URL de la API para obtener los archivos codificados en base64
        api_url = 'http://localhost:5118/api/formulariossoftware/nombrearchivo-filedata'

        # Realiza la solicitud GET a la API
        response = requests.get(api_url)

        # Verifica que la solicitud fue exitosa
        if response.status_code == 200:
            # Convierte la respuesta JSON en una lista de diccionarios
            data = response.json()
            
            # Itera sobre cada formulario en la respuesta
            for formulario in data:
                id_formulario_software = formulario['idFormularioSoftware']
                nombre_archivo = formulario['nombreArchivo']
                file_data_base64 = formulario['fileData']
                estatus = formulario['estatus']
                
                # Si el estatus es False y hay datos codificados en base64, decodifícalos y guarda el archivo
                if not estatus and file_data_base64:
                    try:
                        # Decodifica los datos codificados en base64
                        file_data = base64.b64decode(file_data_base64)
                        
                        # Anteponer el id_formulario_software al nombre del archivo
                        nombre_archivo_con_id = f"{id_formulario_software}_{nombre_archivo}"
                        
                        # Guarda el contenido de los datos binarios en un archivo local
                        with open(os.path.join(path, nombre_archivo_con_id), 'wb') as file:
                            file.write(file_data)
                            
                        print(f'Archivo guardado para el formulario {id_formulario_software} en: {path}\\{nombre_archivo_con_id}')
                    except Exception as e:
                        print(f'Error al decodificar los datos del formulario {id_formulario_software}: {e}')
                    
                else:
                    print(f'No se guardará archivo para el formulario {id_formulario_software}')
        else:
            print(f'Error al obtener los datos de la API: {response.status_code} - {response.text}')

if __name__ == "__main__":
    root = tk.Tk()
    app = ControlGeneralApi(root)
    root.mainloop()
