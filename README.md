[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/1BMWid13)


#Proyecto de Marcadores Geográficos

Descripción: Este proyecto consiste en el desarrollo de una aplicación web que permite obtener y mostrar en un mapa los marcadores geográficos provenientes de una API externa. El backend creado para este proyecto realiza una petición a la API mencionada para obtener un listado de marcadores con su respectiva información (latitud, longitud, etc.).

Características del Backend:
El backend desarrollado expone una API que devuelve todos los marcadores consultados anteriormente. Se implementó un mecanismo de autenticación mediante la API mencionada, donde se debe enviar un usuario y una contraseña en el body de la solicitud. Una vez autenticados, se obtiene un token necesario para realizar consultas a la API de marcadores utilizando autenticación JWT ("Bearer").

Características del Frontend:
El frontend de la aplicación se desarrolló utilizando tecnologías como Bootstrap, JavaScript, JSS y jQuery. Se realizan consultas a la API desarrollada en el backend para obtener los marcadores y se muestran en un mapa utilizando la librería de mapas "HERE Maps". El sitio web es completamente responsive y se aplicaron estilos para lograr una experiencia visualmente agradable.
