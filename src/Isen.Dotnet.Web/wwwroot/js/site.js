// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function() {
    // Teste si ce fichier JS est chargé, et s'il s'exécute
    console.log("JS is running");
    // Teste si la librairie JQuery est chargée
    if ($ != undefined) {
        console.log("JQuery is loaded : " + $);
    }

    loadCities();

    function loadCities() {
        $.ajax({
            // Type de requête HTTP (GET, PÖST, PUT...)
            type: "GET",
            // URL à appeler
            url: "/api/city/",
            // FAIL
            error: function(msg) { console.log(msg); },
            // OK
            success: function(data) {
                // Afficher les données reçues
                console.log(data);
                // Récupérer le div dans lequel on va injecter les data
                var divResult = $("#result")[0];
                // Générer une liste à puces des villes
                var htmlString = "<ul>";
                for(var i = 0 ; i < data.length ; i++) {
                    htmlString += "<li>";
                    htmlString += data[i].name;
                    htmlString += "</li>";
                }
                htmlString += "</ul>";
                // Placer ce html dans le div
                $(divResult).html(htmlString);
            }
        });
    }
})();