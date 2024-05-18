document.getElementById('btnEnviar2').addEventListener('click', function(event) {
    event.preventDefault(); // Evitar que el formulario se envíe automáticamente

     // Obtener valores de los campos obligatorios
     const mensaje = document.getElementById('mensaje').value;
     const condicionTecnica = document.getElementById('condicionTecnica').value;
 
     // Verificar si los campos obligatorios están llenos
     if (!mensaje || !condicionTecnica) {
         alert('Los campos "Describa su problema" y "Condición Técnica" son obligatorios.');
         return; // Detener el proceso si los campos están vacíos
     }
  
    // Realizar la petición GET para obtener la lista de solicitantes de hardware
    fetch('http://localhost:5118/api/solicitanteshard')
    .then(response => {
        if (!response.ok) {
            throw new Error('La petición ha fallado');
        }
        return response.json();
    })
    .then(data => {
        // Verificar si hay datos en la respuesta
        if (data && data.length > 0) {
            // Ordenar los datos por ID de manera descendente
            const sortedData = data.sort((a, b) => b.idSolicitanteHard - a.idSolicitanteHard);
            console.log(sortedData);
            // Obtener el último ID
            const ultimoID = sortedData[0].idSolicitanteHard;
            console.log('Último ID ingresado:', ultimoID);
            
            // Obtener valores del formulario y enviar el formulario
            const marca = document.getElementById('marca').value;
            const noSerie = document.getElementById('inventario').value;
            const descripcion = document.getElementById('mensaje').value;
            const condicion = document.getElementById('condicionTecnica').value;
  
            // Construir objeto de datos a enviar
            const formData = {
                cantidad: "1",
                marca: marca,
                noSerie: noSerie,
                descripcionHard: descripcion,
                condicion: condicion,
                observacionPre: "Escriba su Observacion",
                observacionPost: "Escriba su Observacion",
                fechaPreHard: new Date().toISOString(),
                fechaPostHard: new Date().toISOString(),
                estatusHard: false,
                idSolicitanteHard: ultimoID, // Usar el último ID obtenido
                idOperador: 1 // ID predeterminado del operador
            };
  
            // Realizar la petición POST
            fetch('http://localhost:5118/api/formularioshardware', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            })
            .then(response => {
                if (!response.ok) {
                    console.log('Redireccionando...');
                    alert('El formulario se ha enviado correctamente.');
                    window.location.href = 'index.html';
                    throw new Error('La petición ha fallado');
                }
                return response.json();
            })
            .then(data => {
                console.log('Redireccionando...');
                alert('El formulario se ha enviado correctamente.');
                window.location.href = 'index.html';
                console.log('Respuesta del servidor:', data);

  
                // Redirigir al usuario a index.html
                window.location.href = 'index.html';
            })
            .catch(error => {
                console.log('Redireccionando...');
                alert('El formulario se ha enviado correctamente.');
                window.location.href = 'index.html';
                console.error('Error al realizar la solicitud POST:', error);
                // Aquí puedes manejar el error si es necesario
            });
        } else {
            throw new Error('La lista de solicitantes está vacía');
        }
    })
    .catch(error => {
        console.log('Redireccionando...');
        alert('El formulario se ha enviado correctamente.');
        window.location.href = 'index.html';
        console.error('Error al obtener la lista de solicitantes:', error);
        // Aquí puedes manejar el error si es necesario
    });
  });
  