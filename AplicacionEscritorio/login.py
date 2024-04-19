import tkinter as tk

class Login:
    def __init__(self, master):
        self.master = master
        self.master.title("Inicio de Sesión")

         # Cargar la imagen
        self.imagen = tk.PhotoImage(file="banner.png")  # Ruta de la imagen
        
        # Mostrar la imagen en un widget Label
        self.label_imagen = tk.Label(master, image=self.imagen)
        self.label_imagen.pack()
        
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
        self.boton_login = tk.Button(master, text="Iniciar Sesión", command=self.verificar_login)
        self.boton_login.pack()

    def verificar_login(self):
        # Verificar las credenciales (aquí puedes agregar tu lógica de verificación)
        usuario = self.entry_usuario.get()
        contrasena = self.entry_contrasena.get()

        if usuario == "admin" and contrasena == "admin123":
            self.master.destroy()  # Cerrar la ventana de inicio de sesión
            abrir_ventana_principal()
        else:
            # Mensaje de error en caso de credenciales incorrectas
            tk.messagebox.showerror("Error", "Credenciales incorrectas. Por favor, inténtelo de nuevo.")

def abrir_ventana_principal():
    # Importar y mostrar la ventana principal
    from main import Main
    root = tk.Tk()
    root.geometry("630x300")  # Tamaño fijo para la ventana principal
    app = Main(root)
    root.mainloop()

if __name__ == "__main__":
    root = tk.Tk()
    root.geometry("630x300")  # Tamaño fijo para la ventana principal
    app = Login(root)
    root.mainloop()
