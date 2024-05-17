document.getElementById('btnEnviar1').addEventListener('click', function(event) {
    event.preventDefault(); // Evitar que el formulario se envíe automáticamente

    // Realizar la petición GET para obtener la lista de solicitantes
    fetch('http://localhost:5118/api/solicitantessoft')
    .then(response => {
        if (!response.ok) {
            throw new Error('La petición ha fallado');
        }
        return response.json();
    })
    .then(data => {
        // Ordenar los datos por ID de manera descendente
        const sortedData = data.sort((a, b) => b.idSolicitanteSoft - a.idSolicitanteSoft);
        // Obtener el último ID
        const ultimoID = sortedData[0].idSolicitanteSoft;
        console.log('Último ID ingresado:', ultimoID);
        
        // Obtener valores del formulario y enviar el formulario
        const descripcion = document.getElementById('mensaje').value;
        const imagenInput = document.getElementById('imagen');
        const imagen = imagenInput.files[0];

        // Leer el archivo y convertirlo a base64
        const reader = new FileReader();
        reader.readAsDataURL(imagen);
        reader.onloadend = function() {
            const base64Image = reader.result.split(',')[1]; // Obtener solo la parte base64 del resultado

            // Construir objeto de datos a enviar
            const datos = {
                descripcion: descripcion,
                nombreArchivo: imagen.name,
                fileData: base64Image,
                fechaPre: new Date().toISOString(),
                fechaPost: new Date().toISOString(),
                estatus: false,
                idSolicitanteSoft: ultimoID, // Usar el último ID obtenido
                idOperador: 1 // ID predeterminado del operador
            };

            // Realizar la petición POST
            fetch('http://localhost:5118/api/formulariossoftware', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(datos)
                
            })
            .then(response => {
                if (!response.ok) {
                    console.log('Redireccionando...');
                    window.location.href = 'index.html';
                    throw new Error('La petición ha fallado');
                    
                }
                console.log('Redireccionando...');
                window.location.href = 'index.html';
                return response.json();
            })
            .then(data => {
                console.log('Redireccionando...');
                window.location.href = 'index.html';
                console.log('Respuesta del servidor:', data);
                alert('El formulario se ha enviado correctamente.');

                // Redirigir al usuario a index.html
                console.log('Redireccionando...');
                window.location.href = 'index.html';
            });
        };
    });
});
