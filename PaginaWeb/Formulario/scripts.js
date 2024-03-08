function mostrarOpciones(tipoUsuario) {
    var labelOpcionesCondicionadas = document.getElementById("labelOpcionesCondicionadas");
    var opcionesCondicionadas = document.getElementById("opcionesCondicionadas");

    // Reinicia y oculta las opciones condicionadas al cambiar la selección
    labelOpcionesCondicionadas.style.display = "none";
    opcionesCondicionadas.style.display = "none";
    opcionesCondicionadas.innerHTML = ''; // Limpiar las opciones anteriores

    var labelOpcionesCondicionadasDos = document.getElementById("labelOpcionesCondicionadasDos");
    var opcionesCondicionadasDos = document.getElementById("opcionesCondicionadasDos");
    labelOpcionesCondicionadasDos.style.display = "none";
    opcionesCondicionadasDos.style.display = "none";
    opcionesCondicionadasDos.innerHTML = '';

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

    function agregarOpciones(opciones) {
        opciones.forEach(function (opcion) {
            var option = document.createElement('option');
            option.value = opcion;
            option.textContent = opcion;
            opcionesCondicionadas.appendChild(option);
        });
    }
}

function mostrarOpcionesDos(opcionesCondicionadas) {
    var labelOpcionesCondicionadasDos = document.getElementById("labelOpcionesCondicionadasDos");
    var opcionesCondicionadasDos = document.getElementById("opcionesCondicionadasDos");

    // Reinicia y oculta las opciones condicionadas al cambiar la selección
    labelOpcionesCondicionadasDos.style.display = "none";
    opcionesCondicionadasDos.style.display = "none";
    opcionesCondicionadasDos.innerHTML = ''; // Limpiar las opciones anteriores

    // Muestra las opciones condicionadas según la selección
    if (opcionesCondicionadas === "Subdireccion Academica" || opcionesCondicionadas === "Subdireccion de Planeacion" || opcionesCondicionadas === "Subdireccion de Servicios Administrativos") {
        labelOpcionesCondicionadasDos.style.display = "block";
        opcionesCondicionadasDos.style.display = "block";

        // Agrega las opciones específicas según la selección
        if (opcionesCondicionadas === "Subdireccion Academica") {
            agregarOpciones(['Subdirección', 'Ciencias Basicas', 'Ciencias Economico Administrativas', 'Desarrollo Academico', 'Division de Estudios de Postgrado', 'Division de Estudios Profesionales', 'Ingenieria Industrial', 'Metal Mecanica', 'Sistemas y Computacion']);
        } else if (opcionesCondicionadas === "Subdireccion de Planeacion") {
            agregarOpciones(['Subdirección', 'Actividades Extraescolares', 'Centro de Información', 'Comunicación y Difusión', 'Gestion Tecnológica y Vinculación', 'Planeación Programacion y Presupuesto', 'Servicios Escolares']);
        } else if (opcionesCondicionadas === "Subdireccion de Servicios Administrativos") {
            agregarOpciones(['Subdirección', 'Centro de Cómputo', 'Mantenimiento y Equipo', 'Recursos Financieros', 'Recursos Humanos', 'Recursos Materiales y de Servicios']);
        } 
    }

    function agregarOpciones(opciones) {
        opciones.forEach(function (opcion) {
            var option = document.createElement('option');
            option.value = opcion;
            option.textContent = opcion;
            opcionesCondicionadasDos.appendChild(option);
        });
    }
}

function mostrarOpcionesTipoProblema(tipoProblema) {
    var boton = document.querySelector('button');
    
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

    mostrarOpcionesTipoProblema(tipoProblema);
});
