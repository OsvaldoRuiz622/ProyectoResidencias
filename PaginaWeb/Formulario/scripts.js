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
    if (tipoUsuario === "Personal Administrativo" || tipoUsuario === "Jefe de Departamento" || tipoUsuario === "Tecnico Docente") {
        labelOpcionesCondicionadas.style.display = "block";
        opcionesCondicionadas.style.display = "block";

        // Agrega las opciones específicas según la selección
        if (tipoUsuario === "Personal Administrativo") {
            agregarOpciones(['Direccion', 'Subdireccion Academica', 'Subdireccion de Planeacion', 'Subdireccion de Servicios Administrativos']);
        } else if (tipoUsuario === "Jefe de Departamento") {
            agregarOpciones(['Direccion', 'Subdireccion Academica', 'Subdireccion de Planeacion', 'Subdireccion de Servicios Administrativos']);
        } else if (tipoUsuario === "Tecnico Docente") {
            agregarOpciones(['Direccion', 'Subdireccion Academica', 'Subdireccion de Planeacion', 'Subdireccion de Servicios Administrativos']);
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