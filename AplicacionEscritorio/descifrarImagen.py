import os
import requests
import base64

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
                        
                        # Anteponer el idFormularioSoftware al nombre del archivo
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
