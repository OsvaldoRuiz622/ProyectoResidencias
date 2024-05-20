import tkinter as tk
from PIL import Image, ImageTk
from control_general import ControlGeneralApi
from control_general_hardware import ControlGeneralHardware
from estadisticas import Estadisticas

# Funciones para los botones
def boton1_callback():
    app = Estadisticas()

def abrir_control_general_software():
    # Crear una nueva ventana
    ventana_control_general_software = tk.Toplevel(ventana)
    ventana_control_general_software.title("Control General Software")
    ventana_control_general_software.geometry("800x600")  # Dimensiones de la ventana

    # Instanciar ControlGeneralApi en la nueva ventana
    control_general_software = ControlGeneralApi(ventana_control_general_software)

def boton3_callback():
    ventana_control_general_hardware = tk.Toplevel(ventana)
    ventana_control_general_hardware.title("Control General hardware")
    ventana_control_general_hardware.geometry("800x600")  # Dimensiones de la ventana

    control_general_hardware = ControlGeneralHardware(ventana_control_general_hardware)

    
# Función para cerrar la ventana
def cerrar_ventana():
    ventana.destroy()

# Crear la ventana principal
ventana = tk.Tk()
ventana.title("Sistema de Tickets del Centro de Computo del ITL")

# Dimensiones de la ventana principal
ancho_ventana = 550
alto_ventana = 300
ventana.geometry(f"{ancho_ventana}x{alto_ventana}")

# Crear el frame principal
frame_principal = tk.Frame(ventana)
frame_principal.pack(expand=True, fill='both')

# Cargar imagen para el banner
imagen_banner = Image.open("banner.png")  # Ruta de imagen
imagen_banner = imagen_banner.resize((550, 60), Image.ADAPTIVE)  # Ajustar tamaño
imagen_banner = ImageTk.PhotoImage(imagen_banner)

# Mostrar el banner en un label
label_banner = tk.Label(frame_principal, image=imagen_banner)
label_banner.pack(side="top", fill="both")

# Crear los botones con un tamaño adecuado
boton1 = tk.Button(frame_principal, text="Estadísticas", command=boton1_callback, padx=10, pady=5)
boton1.pack(side="left", padx=20, pady=20)

boton2 = tk.Button(frame_principal, text="Control General Software", command=abrir_control_general_software, padx=10, pady=5)
boton2.pack(side="right", padx=20, pady=20)

boton3 = tk.Button(frame_principal, text="Control General Hardware", command=boton3_callback, padx=10, pady=5)
boton3.pack(side="right", padx=20, pady=20)


# Crear un frame para el botón de cierre
frame_cierre = tk.Frame(ventana)
frame_cierre.pack(side="bottom", fill="x")

# Crear el botón para cerrar la ventana
boton_cerrar = tk.Button(frame_cierre, text="Cerrar Sesión", command=cerrar_ventana)
boton_cerrar.pack(side="bottom", pady=10)

# Centrar los botones verticalmente
frame_principal.grid_columnconfigure(0, weight=1)
frame_principal.grid_columnconfigure(2, weight=1)

# Ejecutar el bucle de eventos
ventana.mainloop()
