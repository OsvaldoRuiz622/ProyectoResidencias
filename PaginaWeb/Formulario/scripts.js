function mostrarOpciones(tipoUsuario) {
    var labelOpcionesCondicionadas = document.getElementById("labelOpcionesCondicionadas");
    var opcionesCondicionadas = document.getElementById("opcionesCondicionadas");

    // Reinicia y oculta las opciones condicionadas al cambiar la selección
    labelOpcionesCondicionadas.style.display = "none";
    opcionesCondicionadas.style.display = "none";
    opcionesCondicionadas.innerHTML = ''; // Limpiar las opciones anteriores

    // Muestra las opciones condicionadas según la selección
    if (tipoUsuario === "Personal Administrativo" || tipoUsuario === "Jefe de Departamento" || tipoUsuario === "Docente") {
        labelOpcionesCondicionadas.style.display = "block";
        opcionesCondicionadas.style.display = "block";

        // Agrega las opciones específicas según la selección
        if (tipoUsuario === "Personal Administrativo") {
            agregarOpciones(['Direccion', 'Subdireccion Academica', 'Subdireccion de Planeacion y Vinculación', 'Subdireccion de Servicios Administrativos', 'DEPARTAMENTO DE SISTEMAS Y COMPUTACIÓN', 'DEPARTAMENTO DE METAL-MECÁNICA', 'DEPARTAMENTO DE CIENCIAS ECONÓMICO ADMINISTRATIVAS', 'DEPARTAMENTO DE INGENIERÍA INDUSTRIAL', 'DEPARTAMENTO DE DESARROLLO ACADÉMICO', 'DIVISIÓN DE ESTUDIOS PROFESIONALES', 'DIVISIÓN DE ESTUDIOS DE POSGRADO E INVESTIGACIÓN', 'DEPARTAMENTO DE CIENCIAS BÁSICAS', 'DEPARTAMENTO DE SERVICIOS ESCOLARES', 'DEPARTAMENTO DE PLANEACIÓN, PROGRAMACIÓN Y PRESUPUESTACIÓN', 'DEPARTAMENTO DE GESTIÓN TECNOLÓGICA Y VINCULACIÓN', 'DEPARTAMENTO DE ACTIVIDADES EXTRAESCOLARES', 'DEPARTAMENTO DE CENTRO DE INFORMACIÓN', 'DEPARTAMENTO DE COMUNICACIÓN Y DIFUSIÓN', 'DEPARTAMENTO DE RECURSOS HUMANOS', 'DEPARTAMENTO DE RECURSOS FINANCIEROS', 'DEPARTAMENTO DE RECURSOS MATERIALES Y DE SERVICIOS', 'DEPARTAMENTO DE MANTENIMIENTO Y EQUIPO', 'DEPARTAMENTO DE CENTRO DE CÓMPUTO']);
        } else if (tipoUsuario === "Jefe de Departamento") {
            agregarOpciones(['Direccion', 'Subdireccion Academica', 'Subdireccion de Planeacion y Vinculación', 'Subdireccion de Servicios Administrativos', 'DEPARTAMENTO DE SISTEMAS Y COMPUTACIÓN', 'DEPARTAMENTO DE METAL-MECÁNICA', 'DEPARTAMENTO DE CIENCIAS ECONÓMICO ADMINISTRATIVAS', 'DEPARTAMENTO DE INGENIERÍA INDUSTRIAL', 'DEPARTAMENTO DE DESARROLLO ACADÉMICO', 'DIVISIÓN DE ESTUDIOS PROFESIONALES', 'DIVISIÓN DE ESTUDIOS DE POSGRADO E INVESTIGACIÓN', 'DEPARTAMENTO DE CIENCIAS BÁSICAS', 'DEPARTAMENTO DE SERVICIOS ESCOLARES', 'DEPARTAMENTO DE PLANEACIÓN, PROGRAMACIÓN Y PRESUPUESTACIÓN', 'DEPARTAMENTO DE GESTIÓN TECNOLÓGICA Y VINCULACIÓN', 'DEPARTAMENTO DE ACTIVIDADES EXTRAESCOLARES', 'DEPARTAMENTO DE CENTRO DE INFORMACIÓN', 'DEPARTAMENTO DE COMUNICACIÓN Y DIFUSIÓN', 'DEPARTAMENTO DE RECURSOS HUMANOS', 'DEPARTAMENTO DE RECURSOS FINANCIEROS', 'DEPARTAMENTO DE RECURSOS MATERIALES Y DE SERVICIOS', 'DEPARTAMENTO DE MANTENIMIENTO Y EQUIPO', 'DEPARTAMENTO DE CENTRO DE CÓMPUTO']);
               } else if (tipoUsuario === "Docente") {
            agregarOpciones(['DEPARTAMENTO DE CIENCIAS BÁSICAS', 'DEPARTAMENTO DE SISTEMAS Y COMPUTACIÓN', 'DEPARTAMENTO DE METAL-MECÁNICA', 'DEPARTAMENTO DE CIENCIAS ECONÓMICO ADMINISTRATIVAS', 'DEPARTAMENTO DE INGENIERÍA INDUSTRIAL', 'DIVISIÓN DE ESTUDIOS PROFESIONALES']);
        }
    }
}

function agregarOpciones(opciones) {
    opciones.forEach(function (opcion) {
        var option = document.createElement('option');
        option.value = opcion;
        option.textContent = opcion;
        opcionesCondicionadas.appendChild(option);
    });
}


function agregarOpciones(opciones) {
    opciones.forEach(function (opcion) {
        var option = document.createElement('option');
        option.value = opcion;
        option.textContent = opcion;
        opcionesCondicionadas.appendChild(option);
    });
}

document.getElementById('btnSiguiente').addEventListener('click', function() {
    // Obtener valores del formulario
    const nombre = document.getElementById('nombre').value;
    const email = document.getElementById('email').value;
    const tipoUsuario = document.getElementById('tipoUsuario').value;
    const area = document.getElementById('opcionesCondicionadas').value;
    const tipoProblema = document.getElementById('tipoProblema').value;

    let url = '';
    let datos = {};

    // Verificar tipo de problema y ajustar URL y datos
    if (["Correo Institucional", "Cuenta Cetech", "Cuenta Office", "Cuenta Aula", "InternetS", "Software"].includes(tipoProblema)) {
        url = 'http://localhost:5118/api/solicitantessoft';
        datos = {
            nombreSolicitanteSoft: nombre,
            correoSoft: email,
            tipoSolicitanteSoft: tipoUsuario,
            areaSoft: area,
            tipoFalloSoft: tipoProblema
        };
    } else {
        url = 'http://localhost:5118/api/solicitanteshard';
        datos = {
            nombreSolicitanteHard: nombre,
            correoHard: email,
            tipoSolicitanteHard: tipoUsuario,
            areaHard: area,
            tipoFalloHard: tipoProblema
        };
    }

    // Realizar la petición POST
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(datos)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('La petición ha fallado');
        }
        // Redirigir la página según la selección del usuario
        if (["Correo Institucional", "Cuenta Cetech", "Cuenta Office", "Cuenta Aula", "InternetS", "Software"].includes(tipoProblema)) {
            window.location.href = "formularioSoftware.html";
        } else {
            window.location.href = "formularioHardware.html";
        }
        return response.json();
    })
    .then(data => {
        console.log('Respuesta del servidor:', data);
        // Aquí puedes manejar la respuesta del servidor, si es necesario
    })
    .catch(error => {
        console.error('Error al enviar datos:', error);
    });
});



