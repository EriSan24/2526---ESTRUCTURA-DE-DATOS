# Traductor Bilingüe - Inglés ↔ Español

## Descripción
Programa en C# que permite traducir palabras y frases entre inglés y español, con opción de agregar nuevas palabras al diccionario.

## Características
✅ **Traducción bidireccional**: Inglés → Español y Español → Inglés  
✅ **Diccionario dinámico**: Agrega nuevas palabras en tiempo de ejecución  
✅ **Detección automática de idioma**: Detecta automáticamente el idioma de entrada  
✅ **Preservación de puntuación**: Mantiene la puntuación en su lugar correcto  
✅ **Validación de entrada**: Manejo robusto de errores  
✅ **Visualización del diccionario**: Ver todas las palabras disponibles

## Requisitos
- .NET 10.0 instalado
- Windows PowerShell o Command Prompt

## Cómo usar

### Opción 1: Usando PowerShell
```powershell
cd "c:\Users\Erick\Documents\GitHub\2526---ESTRUCTURA-DE-DATOS\TareaSemana11\TraductorBilinges"
dotnet run
```

### Opción 2: Ejecutar directamente
```
ejecutar.bat
```

### Opción 3: Compilar solo (sin ejecutar)
```powershell
cd "c:\Users\Erick\Documents\GitHub\2526---ESTRUCTURA-DE-DATOS\TareaSemana11\TraductorBilinges"
dotnet build
```

## Menú Principal
```
1. Traducir una frase     - Traduce una frase completa
2. Agregar palabras       - Añade nuevas palabras al diccionario
3. Ver diccionario        - Muestra todas las palabras (21 iniciales)
0. Salir                  - Cierra el programa
```

## Ejemplos de uso

### Traducción: Inglés → Español
**Entrada:** `time person world`  
**Salida:** `tiempo persona mundo`

### Traducción: Español → Inglés
**Entrada:** `tiempo persona mundo`  
**Salida:** `time person world`

### Con puntuación
**Entrada:** `Hello world!`  
**Salida:** `¡Hola mundo!`

## Palabras iniciales en el diccionario (21)
- time (tiempo)
- person (persona)
- year (año)
- way (camino)
- day (día)
- thing (cosa)
- man (hombre)
- world (mundo)
- life (vida)
- hand (mano)
- part (parte)
- child (niño)
- eye (ojo)
- woman (mujer)
- place (lugar)
- work (trabajo)
- week (semana)
- case (caso)
- point (punto)
- government (gobierno)
- company (empresa)

## Estructura del Proyecto
```
TraductorBilinges/
├── Program.cs                    # Código principal
├── TraductorBilinges.csproj     # Configuración del proyecto
├── ejecutar.bat                 # Script para ejecutar
├── README.md                    # Este archivo
└── bin/
    └── Debug/
        └── net10.0/
            └── TraductorBilinges.exe  # Ejecutable compilado
```

## Métodos principales

### `CrearDiccionarioInverso()`
Genera automáticamente el diccionario inverso (Español → Inglés) a partir del diccionario original.

### `TraducirFrase()`
Traduce una frase completa detectando automáticamente el idioma de entrada.

### `AgregarPalabra()`
Permite agregar nuevas palabras al diccionario de forma bidireccional.

### `MostrarDiccionario()`
Muestra todas las palabras del diccionario ordenadas alfabéticamente.

## Notas técnicas
- Framework: .NET 10.0
- Lenguaje: C#
- Nullable reference types: Habilitado
- Comparación de strings: Case-insensitive

## Estado de compilación
✅ **Compilación exitosa**  
✅ **Ejecutable funcional**  
✅ **Listo para usar**
