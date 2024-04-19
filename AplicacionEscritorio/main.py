import tkinter as tk
from PIL import Image, ImageTk
from estadisticas import Estadisticas
from control_general import ControlGeneralApi
from control_general_hardware import ControlGeneralHardware

# Funciones para los botones
def boton1_callback():
    app = Estadisticas(ventana)

def boton2_callback():
    app = ControlGeneralApi(ventana)

def boton3_callback():
    app = ControlGeneralHardware(ventana)


# Crear la ventana principal
ventana = tk.Tk()
ventana.title("Sistema de Tickets del Centro de Computo del ITL")

# Dimensiones de la ventana principal
ancho_ventana = 530
alto_ventana = 300
ventana.geometry(f"{ancho_ventana}x{alto_ventana}")

# Crear el frame principal
frame_principal = tk.Frame(ventana)
frame_principal.pack(expand=True, fill='both')

# Cargar imagen para el banner
imagen_banner = Image.open("banner.png")  # Ruta de tu imagen
imagen_banner = imagen_banner.resize((ancho_ventana, 50), Image.ADAPTIVE)  # Ajustar tamaño
imagen_banner = ImageTk.PhotoImage(imagen_banner)

# Mostrar el banner en un label
label_banner = tk.Label(frame_principal, image=imagen_banner)
label_banner.pack(side="top", fill="both")

# Crear los botones con un tamaño adecuado
boton1 = tk.Button(frame_principal, text="Estadísticas", command=boton1_callback, padx=10, pady=5)
boton1.pack(side="left", padx=20, pady=20)

boton2 = tk.Button(frame_principal, text="Control General Software", command=boton2_callback, padx=10, pady=5)
boton2.pack(side="right", padx=20, pady=20)

boton3 = tk.Button(frame_principal, text="Control General Hardware", command=boton3_callback, padx=10, pady=5)
boton3.pack(side="right", padx=20, pady=20)

# Centrar los botones verticalmente
frame_principal.grid_columnconfigure(0, weight=1)
frame_principal.grid_columnconfigure(2, weight=1)

# Ejecutar el bucle de eventos
ventana.mainloop()
