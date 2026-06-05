// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    try {
        $(document).ready(function () {

        
            // Función para codificar correctamente en Base64
            function base64Encode(str) {
                return btoa(unescape(encodeURIComponent(str)));
            }

            // Función para convertir Base64 a Blob
            function base64ToBlob(base64, mimeType) {
                const byteCharacters = atob(base64);
                const byteNumbers = new Array(byteCharacters.length);

                for (let i = 0; i < byteCharacters.length; i++) {
                    byteNumbers[i] = byteCharacters.charCodeAt(i);
                }

                const byteArray = new Uint8Array(byteNumbers);
                return new Blob([byteArray], { type: mimeType });
            }

            document.getElementById("downloadBtn").addEventListener("click", () => {
                const svgElement = document.querySelector("#diagramContainer svg");

                if (!svgElement) {
                    alert("No se encontró el SVG.");
                    return;
                }

                // Convertir SVG a string
                const serializer = new XMLSerializer();
                let svgString = serializer.serializeToString(svgElement);

                // Codificar el SVG correctamente a Base64
                const base64Data = base64Encode(svgString);

                // Convertir Base64 en Blob
                const blob = base64ToBlob(base64Data, "image/svg+xml");

                // Crear URL del Blob
                const blobUrl = URL.createObjectURL(blob);

                // Crear y activar el enlace de descarga
                const link = document.createElement("a");
                link.href = blobUrl;
                link.download = "diagrama.svg";
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);

                // Liberar memoria del objeto URL
                URL.revokeObjectURL(blobUrl);
            });
        });
     } catch (error) {
        console.error("Error al inicializar los scripts:", error);
        }
