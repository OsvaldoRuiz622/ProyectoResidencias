function mostrarOpciones(tipoUsuario) {
    var labelOpcionesCondicionadas = document.getElementById("labelOpcionesCondicionadas");
    var opcionesCondicionadas = document.getElementById("opcionesCondicionadas");

    // Reinicia y oculta las opciones condicionadas al cambiar la selección
    labelOpcionesCondicionadas.style.display = "none";
    opcionesCondicionadas.style.display = "none";
    opcionesCondicionadas.innerHTML = ''; // Limpiar las opciones anteriores

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