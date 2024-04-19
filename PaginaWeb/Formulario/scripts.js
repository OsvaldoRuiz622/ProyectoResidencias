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
            agregarOpciones(['Direccion', 'Subdireccion Academica', 'Subdireccion de Planeacion y Vinculación', 'Subdireccion de Servicios Administrativos', 'DEPARTAMENTO DE SISTEMAS Y COMPUTACIÓN', 'DEPARTAMENTO DE METAL-MECÁNICA', 'DEPARTAMENTO DE CIENCIAS ECONÓMICO ADMINISTRATIVAS', 'DEPARTAMENTO DE INGENIERÍA INDUSTRIAL', 'DEPARTAMENTO DE DESARROLLO ACADÉMICO', 'DIVISIÓN DE ESTUDIOS PROFESIONALES', 'DIVISIÓN DE ESTUDIOS DE POSGRADO E INVESTIGACIÓN', 'DEPARTAMENTO DE CIENCIAS BÁSICAS', 'DEPARTAMENTO DE SERVICIOS ESCOLARES', 'DEPARTAMENTO DE PLANEACIÓN, PROGRAMACIÓN Y PRESUPUESTACIÓN', 'DEPARTAMENTO DE GESTIÓN TECNOLÓGICA Y VINCULACIÓN', 'DEPARTAMENTO DE ACTIVIDADES EXTRAESCOLARES', 'CENTRO DE INFORMACIÓN', 'DEPARTAMENTO DE COMUNICACIÓN Y DIFUSIÓN', 'DEPARTAMENTO DE RECURSOS HUMANOS', 'DEPARTAMENTO DE RECURSOS FINANCIEROS', 'DEPARTAMENTO DE RECURSOS MATERIALES Y DE SERVICIOS', 'DEPARTAMENTO DE MANTENIMIENTO Y EQUIPO', 'CENTRO DE CÓMPUTO']);
        } else if (tipoUsuario === "Jefe de Departamento") {
            agregarOpciones(['Direccion', 'Subdireccion Academica', 'Subdireccion de Planeacion y Vinculación', 'Subdireccion de Servicios Administrativos', 'DEPARTAMENTO DE SISTEMAS Y COMPUTACIÓN', 'DEPARTAMENTO DE METAL-MECÁNICA', 'DEPARTAMENTO DE CIENCIAS ECONÓMICO ADMINISTRATIVAS', 'DEPARTAMENTO DE INGENIERÍA INDUSTRIAL', 'DEPARTAMENTO DE DESARROLLO ACADÉMICO', 'DIVISIÓN DE ESTUDIOS PROFESIONALES', 'DIVISIÓN DE ESTUDIOS DE POSGRADO E INVESTIGACIÓN', 'DEPARTAMENTO DE CIENCIAS BÁSICAS', 'DEPARTAMENTO DE SERVICIOS ESCOLARES', 'DEPARTAMENTO DE PLANEACIÓN, PROGRAMACIÓN Y PRESUPUESTACIÓN', 'DEPARTAMENTO DE GESTIÓN TECNOLÓGICA Y VINCULACIÓN', 'DEPARTAMENTO DE ACTIVIDADES EXTRAESCOLARES', 'CENTRO DE INFORMACIÓN', 'DEPARTAMENTO DE COMUNICACIÓN Y DIFUSIÓN', 'DEPARTAMENTO DE RECURSOS HUMANOS', 'DEPARTAMENTO DE RECURSOS FINANCIEROS', 'DEPARTAMENTO DE RECURSOS MATERIALES Y DE SERVICIOS', 'DEPARTAMENTO DE MANTENIMIENTO Y EQUIPO', 'CENTRO DE CÓMPUTO']);
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




document.getElementById("btnSiguiente").addEventListener("click", function(event) {
    event.preventDefault(); // Evita que el formulario se envíe automáticamente

    var nombre = document.getElementById("nombre").value.trim();
    var email = document.getElementById("email").value.trim();

    if (nombre === "" || email === "") {
        alert("Por favor, completa todos los campos antes de continuar.");
    } else {
        var problemaSeleccionado = document.getElementById("tipoProblema").value;
        if (problemaSeleccionado === "Correo Institucional" || 
            problemaSeleccionado === "Cuenta Cetech" || 
            problemaSeleccionado === "Cuenta Office" || 
            problemaSeleccionado === "Cuenta Aula" || 
            problemaSeleccionado === "InternetS" || 
            problemaSeleccionado === "Software") {
            window.location.href = "formularioSoftware.html";
        } else {
            window.location.href = "formularioHardware.html";
        }
    }
});



