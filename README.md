#8-Puzzle Solver (A* Search in C#)

Este proyecto implementa el clásico "problema del 8-Puzzle" en "C#", siguiendo la estructura y patrones presentados en el libro  
“Design Patterns for Searching in C#”.

Características
- Modo manual: el jugador mueve las fichas con las teclas `W`, `A`, `S`, `D`.
- Modo automático: el programa resuelve el puzzle usando **A\*** con heurística "Manhattan".
- Diseño modular con clases `State`, `Node`, `SearchAlgorithm`, y `AStarSearch`.

Objetivo del juego
Llevar el tablero desde el "estado inicial" hasta el "estado meta", moviendo una ficha por vez (usando el espacio vacío).

