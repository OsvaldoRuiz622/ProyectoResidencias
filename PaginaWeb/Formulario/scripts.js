function mostrarOpciones(tipoUsuario) {
    var labelOpcionesCondicionadas = document.getElementById("labelOpcionesCondicionadas");
    var opcionesCondicionadas = document.getElementById("opcionesCondicionadas");

    // Reinicia y oculta las opciones condicionadas al cambiar la selección
    labelOpcionesCondicionadas.style.display = "none";
    opcionesCondicionadas.style.display = "none";
    opcionesCondicionadas.innerHTML = ''; // Limpiar las opciones anteriores

    // Muestra las opciones condicionadas según la selección
    if (tipoUsuario === "Personal Administrativo" || tipoUsuario === "Jefe de Departamento" || tipoUsuario === "Tecnico Docente" || tipoUsuario === "Docente") {
        labelOpcionesCondicionadas.style.display = "block";
        opcionesCondicionadas.style.display = "block";

        // Agrega las opciones específicas según la selección
        if (tipoUsuario === "Personal Administrativo") {
            agregarOpciones(['Direccion', 'Subdireccion Academica', 'Subdireccion de Planeacion y Vinculación', 'Subdireccion de Servicios Administrativos', 'DEPARTAMENTO DE SISTEMAS Y COMPUTACIÓN', 'DEPARTAMENTO DE METAL-MECÁNICA', 'DEPARTAMENTO DE CIENCIAS ECONÓMICO ADMINISTRATIVAS', 'DEPARTAMENTO DE INGENIERÍA INDUSTRIAL', 'DEPARTAMENTO DE DESARROLLO ACADÉMICO', 'DIVISIÓN DE ESTUDIOS PROFESIONALES', 'DIVISIÓN DE ESTUDIOS DE POSGRADO E INVESTIGACIÓN', 'DEPARTAMENTO DE CIENCIAS BÁSICAS', 'DEPARTAMENTO DE SERVICIOS ESCOLARES', 'DEPARTAMENTO DE PLANEACIÓN, PROGRAMACIÓN Y PRESUPUESTACIÓN', 'DEPARTAMENTO DE GESTIÓN TECNOLÓGICA Y VINCULACIÓN', 'DEPARTAMENTO DE ACTIVIDADES EXTRAESCOLARES', 'CENTRO DE INFORMACIÓN', 'DEPARTAMENTO DE COMUNICACIÓN Y DIFUSIÓN', 'DEPARTAMENTO DE RECURSOS HUMANOS', 'DEPARTAMENTO DE RECURSOS FINANCIEROS', 'DEPARTAMENTO DE RECURSOS MATERIALES Y DE SERVICIOS', 'DEPARTAMENTO DE MANTENIMIENTO Y EQUIPO', 'CENTRO DE CÓMPUTO']);
        } else if (tipoUsuario === "Jefe de Departamento") {
            agregarOpciones(['Direccion', 'Subdireccion Academica', 'Subdireccion de Planeacion y Vinculación', 'Subdireccion de Servicios Administrativos', 'DEPARTAMENTO DE SISTEMAS Y COMPUTACIÓN', 'DEPARTAMENTO DE METAL-MECÁNICA', 'DEPARTAMENTO DE CIENCIAS ECONÓMICO ADMINISTRATIVAS', 'DEPARTAMENTO DE INGENIERÍA INDUSTRIAL', 'DEPARTAMENTO DE DESARROLLO ACADÉMICO', 'DIVISIÓN DE ESTUDIOS PROFESIONALES', 'DIVISIÓN DE ESTUDIOS DE POSGRADO E INVESTIGACIÓN', 'DEPARTAMENTO DE CIENCIAS BÁSICAS', 'DEPARTAMENTO DE SERVICIOS ESCOLARES', 'DEPARTAMENTO DE PLANEACIÓN, PROGRAMACIÓN Y PRESUPUESTACIÓN', 'DEPARTAMENTO DE GESTIÓN TECNOLÓGICA Y VINCULACIÓN', 'DEPARTAMENTO DE ACTIVIDADES EXTRAESCOLARES', 'CENTRO DE INFORMACIÓN', 'DEPARTAMENTO DE COMUNICACIÓN Y DIFUSIÓN', 'DEPARTAMENTO DE RECURSOS HUMANOS', 'DEPARTAMENTO DE RECURSOS FINANCIEROS', 'DEPARTAMENTO DE RECURSOS MATERIALES Y DE SERVICIOS', 'DEPARTAMENTO DE MANTENIMIENTO Y EQUIPO', 'CENTRO DE CÓMPUTO']);
        } else if (tipoUsuario === "Tecnico Docente") {
            agregarOpciones(['DEPARTAMENTO DE CIENCIAS BÁSICAS', 'DEPARTAMENTO DE SISTEMAS Y COMPUTACIÓN', 'DEPARTAMENTO DE METAL-MECÁNICA', 'DEPARTAMENTO DE CIENCIAS ECONÓMICO ADMINISTRATIVAS', 'DEPARTAMENTO DE INGENIERÍA INDUSTRIAL', 'DEPARTAMENTO DE DESARROLLO ACADÉMICO', 'DIVISIÓN DE ESTUDIOS PROFESIONALES', 'DIVISIÓN DE ESTUDIOS DE POSGRADO E INVESTIGACIÓN']);
        } else if (tipoUsuario === "Docente") {
            agregarOpciones(['DEPARTAMENTO DE CIENCIAS BÁSICAS', 'DEPARTAMENTO DE SISTEMAS Y COMPUTACIÓN', 'DEPARTAMENTO DE METAL-MECÁNICA', 'DEPARTAMENTO DE CIENCIAS ECONÓMICO ADMINISTRATIVAS', 'DEPARTAMENTO DE INGENIERÍA INDUSTRIAL', 'DEPARTAMENTO DE DESARROLLO ACADÉMICO', 'DIVISIÓN DE ESTUDIOS PROFESIONALES', 'DIVISIÓN DE ESTUDIOS DE POSGRADO E INVESTIGACIÓN']);
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


function mostrarOpcionesTipoProblema(tipoProblema, botonId) {
    var boton = document.getElementById(botonId);
    
    // URL de redirección para cada tipo de problema
    var redirectURL;
    switch (tipoProblema) {
        case 'Cuenta Institucional':
        case 'InternetS':
        case 'Software':
            redirectURL = 'formularioSoftware.html';
            break;
        default:
            redirectURL = 'formularioHardware.html';
    }

    // Agregar el evento de clic al botón para la redirección
    boton.addEventListener('click', function () {
        window.location.href = redirectURL;
    });
}

document.addEventListener('DOMContentLoaded', function () {
    var tipoProblema = document.getElementById('tipoProblemaUsuario').value;

    mostrarOpcionesTipoProblema(tipoProblema, 'btnSiguiente');
});
