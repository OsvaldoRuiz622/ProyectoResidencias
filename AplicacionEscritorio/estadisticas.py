import tkinter as tk
from tkinter import ttk, Menu
import requests
import matplotlib.pyplot as plt

class Estadisticas(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Estadísticas")
        self.geometry("400x150") 

        self.software_menu = Menu(self, tearoff=0)
        self.hardware_menu = Menu(self, tearoff=0)

        self.software_menu.add_command(label="Tipo de Solicitante", command=lambda: self.open_new_window("Tipo de Solicitante", "software"))
        self.software_menu.add_command(label="Área", command=lambda: self.open_new_window("Área", "software"))
        self.software_menu.add_command(label="Tipo de Fallo", command=lambda: self.open_new_window("Tipo de Fallo", "software"))

        self.hardware_menu.add_command(label="Tipo de Solicitante", command=lambda: self.open_new_window("Tipo de Solicitante", "hardware"))
        self.hardware_menu.add_command(label="Área", command=lambda: self.open_new_window("Área", "hardware"))
        self.hardware_menu.add_command(label="Tipo de Fallo", command=lambda: self.open_new_window("Tipo de Fallo", "hardware"))

        self.software_button = ttk.Menubutton(self, text="Software", menu=self.software_menu)
        self.software_button.pack(fill="both", expand=True, padx=20, pady=5)
        self.hardware_button = ttk.Menubutton(self, text="Hardware", menu=self.hardware_menu)
        self.hardware_button.pack(fill="both", expand=True, padx=20, pady=5)

    def open_new_window(self, option, category):
        nueva_ventana = tk.Toplevel(self)
        nueva_ventana.title("Estadísticas - {}".format(option))
        nueva_ventana.geometry("400x300")

        if option == "Tipo de Solicitante":
            if category == "software":
                self.display_solicitante_statistics(nueva_ventana, "software")
            else:
                self.display_solicitante_statistics(nueva_ventana, "hardware")
        elif option == "Área":
            if category == "software":
                self.display_area_statistics(nueva_ventana, "software")
            else:
                self.display_area_statistics(nueva_ventana, "hardware")
        elif option == "Tipo de Fallo":
            if category == "software":
                self.display_fallo_statistics(nueva_ventana, "software")
            else:
                self.display_fallo_statistics(nueva_ventana, "hardware")

    def fetch_data_from_api(self, url):
        response = requests.get(url)
        if response.status_code == 200:
            return response.json()
        else:
            print("Error al obtener datos de la API")
            return []

    def display_solicitante_statistics(self, window, category):
        if category == "software":
            url = "http://localhost:5118/api/solicitantessoft"
        else:
            url = "http://localhost:5118/api/solicitanteshard"

        data = self.fetch_data_from_api(url)

        
        count_dict = {}
        for item in data:
            tipo_solicitante = item.get("tipoSolicitanteSoft" if category == "software" else "tipoSolicitanteHard")
            if tipo_solicitante in count_dict:
                count_dict[tipo_solicitante] += 1
            else:
                count_dict[tipo_solicitante] = 1

        
        label = tk.Label(window, text=f"Estadísticas de Tipo de Solicitante {'(Software)' if category == 'software' else '(Hardware)'}")
        label.pack()

        
        plt.bar(count_dict.keys(), count_dict.values())
        plt.xlabel("Tipo de Solicitante")
        plt.ylabel("Cantidad")
        plt.xticks(rotation=45)
        plt.tight_layout()
        plt.show()

    def display_area_statistics(self, window, category):
        if category == "software":
            url = "http://localhost:5118/api/solicitantessoft"
        else:
            url = "http://localhost:5118/api/solicitanteshard"

        data = self.fetch_data_from_api(url)

        
        count_dict = {}
        for item in data:
            area = item.get("areaSoft" if category == "software" else "areaHard")
            if area in count_dict:
                count_dict[area] += 1
            else:
                count_dict[area] = 1

        
        label = tk.Label(window, text=f"Estadísticas de Área {'(Software)' if category == 'software' else '(Hardware)'}")
        label.pack()

        
        plt.bar(count_dict.keys(), count_dict.values())
        plt.xlabel("Área")
        plt.ylabel("Cantidad")
        plt.xticks(rotation=45)
        plt.tight_layout()
        plt.show()

    def display_fallo_statistics(self, window, category):
        if category == "software":
            url = "http://localhost:5118/api/solicitantessoft"
        else:
            url = "http://localhost:5118/api/solicitanteshard"

        data = self.fetch_data_from_api(url)

        
        count_dict = {}
        for item in data:
            tipo_fallo = item.get("tipoFalloSoft" if category == "software" else "tipoFalloHard")
            if tipo_fallo in count_dict:
                count_dict[tipo_fallo] += 1
            else:
                count_dict[tipo_fallo] = 1

       
        label = tk.Label(window, text=f"Estadísticas de Tipo de Fallo {'(Software)' if category == 'software' else '(Hardware)'}")
        label.pack()

        
        plt.bar(count_dict.keys(), count_dict.values())
        plt.xlabel("Tipo de Fallo")
        plt.ylabel("Cantidad")
        plt.xticks(rotation=45)
        plt.tight_layout()
        plt.show()

if __name__ == "__main__":
    app = Estadisticas()
    app.mainloop()
