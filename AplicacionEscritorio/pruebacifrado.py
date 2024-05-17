import hashlib

def cifrar_con_sha256(palabra):
    # Utilizamos encode() para convertir la cadena a bytes
    # Luego aplicamos el algoritmo SHA-256
    palabra_cifrada = hashlib.sha256(palabra.encode()).hexdigest()
    return palabra_cifrada

if __name__ == "__main__":
    palabra = input("Ingresa la palabra a cifrar: ")
    
    palabra_cifrada = cifrar_con_sha256(palabra)
    
    print("Palabra original:", palabra)
    print("Palabra cifrada:", palabra_cifrada)
