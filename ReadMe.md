### CARLOS ALBERTO MARICHAL CALA C-112
# Cómo Jugar el Juego de Aventuras en Tartaria

## Objetivo del Juego
Tu objetivo es navegar por el Laberinto de las Sombras, recolectar banderas y encontrar la salida. Cada bandera que recojas te acercará a la victoria.

---

## Requisitos
No todos los requisitos son obligatorios, pero se recomienda cumplir con la mayoría para una mejor experiencia de juego.

- Visual Studio 2022: Instalado con el lenguaje C# y la extensión de Windows Forms.
  - Descargar el instalador buscando en el navegador: _"descargar vs 2022 gratis"_.
- .NET Framework: Se recomienda la versión 7 o superior.
  - Al instalar Visual Studio, se ofrece la opción de descargar la versión más reciente.
- Sistema Operativo: Comprobado en Windows 10 Enterprise versión 22H2.

---

## Preparativos (Opciones)
1. Abrir la aplicación:
   - Ejecuta la aplicación Maze Runners que se encuentra en la ruta: bin/Debug.
2. Ejecutar desde Visual Studio:
   - Abre el proyecto en Visual Studio y ejecútalo directamente desde allí.

---

## Controles

### Movimiento
- Usa las teclas W, A, S, D para mover tu ficha activa:
  - W: Mover hacia arriba.
  - S: Mover hacia abajo.
  - A: Mover hacia la izquierda.
  - D: Mover hacia la derecha.

### Cambiar Ficha Activa
- Presiona Q (Jugador 1) o E (Jugador 2) para cambiar entre tus fichas.
  - Recomendación: Después de mover una ficha, presiona Q o E para ver qué ficha está utilizando el otro jugador en el siguiente turno.

---

## Recolección de Banderas
- Al mover tu ficha activa a una celda que contenga una bandera, esta será recolectada automáticamente.
- Cada bandera que recojas suma a tu puntuación.

---

## Ganar el Juego
- El juego termina cuando un jugador recoge todas las banderas requeridas o logra salir del laberinto.
- El jugador que haya recogido más banderas al final del juego es declarado el ganador.

---

## Resumen
Disfruta de la aventura mientras exploras el laberinto, recolectas banderas y compites con otros jugadores. ¡Buena suerte en tu búsqueda en Tartaria!

---

## Descripción del Código

### Declaración de Variables
- Se utilizan valores impares para crear una matriz de tipo bool (donde false representa las paredes).
- Las banderas (flags) se almacenan en una lista, al igual que las trampas. Estas últimas se diferencian mediante un Dictionary (lista enumerada) para poder trabajarlas individualmente.
- Un array almacena las puntuaciones de los jugadores, y un Point verifica las posiciones de los jugadores.
- La variable extraMove (tipo bool) se utiliza para verificar si un turno es doble o no.

### Inicialización del Juego
- En el constructor FormJuego, se inicializan las variables:
  - Las puntuaciones comienzan en 0.
  - Se desactiva el movimiento doble al inicio.

### Generación del Laberinto
- El botón btnGenerarLaberinto_Click crea el tablero:
  - Llena el laberinto de obstáculos y vacía la posición (1, 1).
- El método GenerateMaze utiliza un algoritmo de Backtracking para generar el laberinto a partir de la posición (1, 1) (excluyendo los bordes).
  - Recorre las direcciones posibles (4 en total), calcula una nueva posición, verifica si es válida y la marca como camino.
  - Llama recursivamente a GenerateMaze para continuar generando el laberinto.

### Generación de Banderas y Trampas
- El método GenerateFlags genera 7 banderas en posiciones aleatorias, verificando que la casilla esté vacía y no sea un borde.
- El método GenerateTraps genera 18 trampas en posiciones aleatorias, asegurándose de que no estén en los bordes ni en casillas ocupadas.

### Posiciones de los Jugadores
- El método InitializePlayerPositions coloca las fichas de los jugadores en posiciones aleatorias dentro del laberinto, evitando superponerlas con banderas o trampas.

### Dibujo del Laberinto
- El método DrawMaze se encarga de pintar el laberinto, las banderas, las trampas y las fichas de los jugadores en el PictureBox.
### Manejo de Controles
- El método ProcessCmdKey asigna las teclas a los movimientos y cambios de turno de las fichas.
- El método MovePlayer gestiona los movimientos, verificando si son válidos mediante IsValidMove.

### Efectos de las Trampas
- El método HandleTrapEffect maneja los efectos de las trampas:
  - Tipo 1: Pierdes un turno.
  - Tipo 2: Retrocedes a una posición anterior.
  - Tipo 3: Teletransportación a una nueva posición.
  - Tipo 4: Movimiento doble en el turno actual.

### Retroceso y Teletransporte
- El método MoveBackSpaces verifica si puedes retroceder dos pasos en una dirección válida.
- El método TeleportToRandomPosition teletransporta la ficha a una posición aleatoria dentro del laberinto.

### Cambio de Ficha Activa
- El método ChangeActivePiece permite al jugador cambiar entre sus fichas activas.

### Verificación de Banderas
- El método CheckFlagCollection verifica si un jugador ha recolectado 4 banderas (mayoría) para ganar y finalizar el juego.

### Actualización de la Interfaz
- Los métodos UpdateScore y UpdateTurnLabel actualizan las etiquetas que muestran las puntuaciones y el turno actual.

### Botón de Salida
- El botón btnSalir cierra la aplicación.
