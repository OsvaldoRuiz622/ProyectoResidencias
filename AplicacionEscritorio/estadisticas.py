import tkinter as tk
from tkinter import ttk, Menu

class Estadisticas(tk.Toplevel):
    def __init__(self, parent):
        super().__init__(parent)
        self.parent = parent
        self.title("Estadísticas")
        self.geometry("400x150") 

        # Create a split button with 5 options
        self.split_button = ttk.Menubutton(self, text="Selecciona una opción")
        self.split_button.pack(fill="both", expand=True, padx=20, pady=20)

        # Create a menu for the split button
        self.menu = Menu(self.split_button, tearoff=0)
        self.split_button["menu"] = self.menu

        # Add options to the menu
        self.menu.add_command(label="Departamento", command=lambda: self.set_text("Departamento"))
        self.menu.add_command(label="Carrera", command=lambda: self.set_text("Carrera"))
        self.menu.add_command(label="Peticiones Software", command=lambda: self.set_text("Peticiones Software"))
        self.menu.add_command(label="Peticiones Hardware", command=lambda: self.set_text("Peticiones Hardware"))

         # Create a button to open a new window

        self.new_window_button = tk.Button(self, text="Ir a estadistica", command=self.open_new_window)

        self.new_window_button.pack(fill="both", expand=True, padx=20, pady=20)


        # Initialize the text of the Menubutton

        self.set_text("Selecciona una opción")


    def set_text(self, text):
        # Set the text of the Menubutton and configure it to display the new text
        self.split_button.configure(text=text)
        self.split_button.state(['!disabled'])

    def open_new_window(self):
        # Create a new window
        nueva_ventana = tk.Toplevel(self)
        nueva_ventana.title("Nueva ventana")
        nueva_ventana.geometry("300x200")

        # Add some content to the new window
        label = tk.Label(nueva_ventana, text="Esta es una nueva ventana")
        label.pack(fill="both", expand=True, padx=20, pady=20)      