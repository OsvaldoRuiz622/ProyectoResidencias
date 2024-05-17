import tkinter as tk
from PIL import Image, ImageTk
import requests
from tkinter import messagebox
import hashlib

class Login:
    def __init__(self, master):
        self.master = master
        self.master.title("Inicio de Sesión")

        self.imagen = Image.open("banner.png")  
        self.imagen = self.imagen.resize((600, 80), Image.ADAPTIVE)
        self.imagen = ImageTk.PhotoImage(self.imagen)

        # Mostrar la imagen en un label
        self.label_imagen = tk.Label(master, image=self.imagen)
        self.label_imagen.pack()

        texto_bienvenida = tk.Label(master, text="Bienvenidos al Sistema de Tickets del Centro de Cómputo del ITL", font=("Arial", 12, "bold"))
        texto_bienvenida.pack()

        texto_bienvenida2 = tk.Label(master, text="Ingrese sus credenciales", font=("Arial", 10, "bold"))
        texto_bienvenida2.pack()

        # Campos de usuario y contraseña
        self.label_usuario = tk.Label(master, text="Usuario:")
        self.label_usuario.pack()
        self.entry_usuario = tk.Entry(master)
        self.entry_usuario.pack()

        self.label_contrasena = tk.Label(master, text="Contraseña:")
        self.label_contrasena.pack()
        self.entry_contrasena = tk.Entry(master, show="*")
        self.entry_contrasena.pack()

        # Botón de inicio de sesión
        self.boton_login = tk.Button(master, text="Iniciar Sesión", command=self.iniciar_sesion)
        self.boton_login.pack()

    def iniciar_sesion(self):
        usuario = self.entry_usuario.get()
        contrasena = self.entry_contrasena.get()

        try:
            operador = self.verificar_credenciales(usuario, contrasena)
            if operador:
                self.master.destroy()
                if operador['cargo'] == "Jefe de Departamento":
                    self.abrir_ventana_principal()
                else:
                    self.abrir_subventana_principal()
            else:
                messagebox.showerror("Error", "Credenciales incorrectas. Por favor, inténtelo de nuevo.")
        except requests.exceptions.RequestException:
            messagebox.showerror("Error", "No se pudo conectar con el servidor. Por favor, inténtelo de nuevo más tarde.")

    def verificar_credenciales(self, usuario, contrasena):
        # Calcular el hash SHA-256 de la contraseña ingresada por el usuario
        contrasena_hash = hashlib.sha256(contrasena.encode()).hexdigest()

        response = requests.get('http://localhost:5118/api/operadores')
        response.raise_for_status()
        operadores = response.json()

        for operador in operadores:
            # Comparar el nombre de usuario y el hash de la contraseña con los de la base de datos
            if operador['usuario'] == usuario and operador['contrasena'] == contrasena_hash:
                return operador
        return None

    def abrir_ventana_principal(self):
        from main import Main
        root = tk.Tk()
        root.geometry("630x300")
        app = Main(root)
        root.mainloop()

    def abrir_subventana_principal(self):
        from submain import SubMain
        root = tk.Tk()
        root.geometry("630x300")
        app = SubMain(root)
        root.mainloop()

if __name__ == "__main__":
    root = tk.Tk()
    root.geometry("630x300")
    app = Login(root)
    root.mainloop()
