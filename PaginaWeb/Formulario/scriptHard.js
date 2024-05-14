document.getElementById('btnEnviar2').addEventListener('click', function(event) {
    event.preventDefault(); // Evitar que el formulario se envíe automáticamente

    // Realizar la petición GET para obtener la lista de solicitantes
    fetch('http://localhost:5213/api/solicitantes')
    .then(response => {
        if (!response.ok) {
            throw new Error('La petición ha fallado');
        }
        return response.json();
    })
    .then(data => {
        // Obtener el último ID ingresado
        const ultimoID = data[data.length - 1].idSolicitante;

        // Imprimir el último ID en la consola para probar
        console.log('Último ID ingresado:', ultimoID);

        // Obtener valores del formulario
        const descripcion = document.getElementById('mensaje').value;
        const condicion = document.getElementById('condicionTecnica').value;
        const marca = document.getElementById('marca').value;
        const inventario = document.getElementById('inventario').value;

        // Construir objeto de datos a enviar
        const datos = {
            cantidad: '1',
            marca: marca,
            noSerie: inventario,
            descripcion: descripcion,
            condicion: condicion,
            observacionPre: '',
            observacionPost: '',
            fechaPre: new Date().toISOString(),
            fechaPost: new Date().toISOString(),
            idSolicitante: ultimoID, // Usar el último ID obtenido
            idOperador: 1 // ID predeterminado del operador
        };

        // Realizar la petición POST
        return fetch('http://localhost:5213/api/formulariohardware', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(datos)
        });
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('La petición ha fallado');
        }
        return response.json();
    })
    .then(data => {
        console.log('Respuesta del servidor:', data);
    })
    .catch(error => {
        console.error('Error al enviar datos:', error);
    });
});
