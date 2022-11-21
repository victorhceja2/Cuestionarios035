Por Victor Ceja
Cuando se ejecute docker en un servidor linux como Centos o otro
al momento de hacer el buid del docker falla "No descarga los paquetes nuget"
se incluye un archivo proxy que se debe copiar en "/etc/docker"
el archivo se llama "daemon.json"
se tiene que resetear el servicio de docker.

