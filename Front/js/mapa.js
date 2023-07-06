//URL de la API desde donde se obtienen los marcadores.
const API_MARCADORES_URL = "https://localhost:7145/api/marcador/getMarcadores"; 

//instancia de la clase H.service.Platform con la clave de API proporcionada.
//Esta clase es parte de la API HERE Maps y permite interactuar con los servicios de mapas.
var platform = new H.service.Platform({
  apikey: 'FtcN3kvDo9iEOHKbEOSEUw'
});

//Se crea un objeto defaultLayers que contiene las capas predeterminadas
//del mapa, como las capas de vectores normales.
var defaultLayers = platform.createDefaultLayers();
var map = new H.Map(
  document.getElementById('mapContainer'),
  defaultLayers.vector.normal.map, {
    center: { lat: -31.4135, lng: -64.18105 },
    zoom: 12,
    pixelRatio: window.devicePixelRatio || 1  
  }
);

//Se crea un objeto behavior que habilita la interacción del usuario con el mapa, como hacer zoom o arrastrar.
//Se crea un objeto ui que crea los elementos de interfaz de usuario predeterminados del mapa, como los controles de zoom.
var behavior = new H.mapevents.Behavior(new H.mapevents.MapEvents(map));
var ui = H.ui.UI.createDefault(map, defaultLayers);

//Se define una función addMarkerToMap(coordinates) que agrega un marcador al mapa en las coordenadas especificadas.
function addMarkerToMap(coordinates) {
  var marker = new H.map.Marker(coordinates);
  map.addObject(marker);
}


//Se define una función cargarMarcadores() que inicializa el mapa y carga los marcadores 
// mediante una solicitud fetch a la URL API_MARCADORES_URL. Los marcadores se obtienen como 
// respuesta en formato JSON y se agregan al mapa uno por uno como objetos H.map.Marker. 
// También se configuran eventos de clic para los marcadore

function cargarMarcadores() {
  console.log('Inicializando mapa')
  fetch(API_MARCADORES_URL)
    .then((respuesta) => respuesta.json())
    .then((respuesta) => {
      if (respuesta.statusCode !== 200) {
        alert('Error al cargar los marcadores!!!');       
        return;
      } else {
        respuesta.litadoMarcadores.forEach(marcador => {
          var marker = new H.map.Marker({
            lat: marcador.latitud,
            lng: marcador.longitud
          });
          marker.setData({
            info: marcador.info            
          });
          console.log(marcador.info)
          marker.addEventListener('tap', onMarkerClick);
          map.addObject(marker);
          console.log('Está agregando los marcadores')
        });
      }
    });
}

//se activa cuando se hace clic en un marcador. Esta función obtiene la información del marcador 
//y muestra una ventana de información (InfoBubble) en el mapa con el contenido de la información.
function onMarkerClick(event) {
  var marker = event.target;
  var data = marker.getData();

  var infoWindow = new H.ui.InfoBubble(marker.getGeometry(), {
    content: data.info 
  });
  ui.addBubble(infoWindow);
}

//me traigo el boton del html
let btnMostrarMarcadores = document.getElementById('btnMostrarMarcadores');

//le asigno la funcion cargarMarcadores al evento de click
btnMostrarMarcadores.addEventListener("click", cargarMarcadores)

//---------------------------------------------------------------------------------------------------------

// Esto fue para la v1 en la que se cargaban los amrcadores cuando se levantaba la pagina:

 //document.addEventListener('DOMContentLoaded', cargarMarcadores);



