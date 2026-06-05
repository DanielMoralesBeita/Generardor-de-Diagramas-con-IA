# Generardor-de-Diagramas-con-IA
Genera diagramas con IA primero pensaba en venderlo pero después pensé que podría ayudar a las personas si lo saben configurar
<img width="1903" height="1053" alt="image" src="https://github.com/user-attachments/assets/59606ed2-e929-4f77-8590-3078c22ed299" />
Ahi eliges el diagrama y pones lo que quieres y el modelo ya sea de opeia o de ollama.

# AI-Powered Diagram se base en mermain js para rederizas 

Un generador y motor de diagramado interactivo asistido por Inteligencia Artificial, diseñado bajo el patrón arquitectónico Model-Vista-Controlador (MVC). Este software permite a desarrolladores y arquitectos de sistemas traducir descripciones conceptuales o código en representaciones visuales, utilizando tanto Modelos de Lenguaje Grandes (LLMs) locales como APIs comerciales.

## 🚀 Características Clave

- **Inferencia Local (Privacidad Total):** Integración nativa con **Ollama** (optimizado para Mistral), permitiendo procesar y generar diagramas de forma 100% offline sin comprometer la propiedad intelectual del código o las ideas.
- **Integración con Cloud AI:** Soporte para la API oficial de **OpenAI** para una precisión semántica avanzada.
- **Arquitectura Desacoplada (MVC):** El flujo de control, la interfaz del usuario y los motores de parseo/IA están separados para facilitar la modularidad.

## 🛠️ Estado del Proyecto y Filosofía Lean

Este proyecto ha sido liberado bajo un enfoque **Lean (MVP)**. El núcleo lógico y las conexiones con las IA son completamente funcionales. Sin embargo, reconocemos la existencia de deuda técnica y oportunidades de refactorización en el código base. 

Hemos decidido abrir el repositorio de manera temprana para:
1. Validar el valor de la herramienta con usuarios reales.
2. Permitir que la arquitectura evolucione orgánicamente mediante la colaboración *Open Source*.
3. Dejar un sistema base modular abierto a mejoras de optimización.

## 🏗️ Arquitectura de Alto Nivel

El software implementa una variación del patrón MVC para desacoplar el procesamiento semántico de la renderización visual:

- **Model:** Gestiona el estado del grafo, los nodos, las conexiones y las peticiones a los motores de IA (Ollama/OpenAI API Client).
- **View:** Encargada de la representación gráfica del diagrama y la interacción del usuario.
- **Controller:** Coordina el flujo, intercepta los prompts o entradas del usuario, invoca los analizadores de los modelos de IA y actualiza la estructura del modelo visual.

## ⚡ Requisitos Previos

- Para ejecución local: Tener instalado [Ollama](https://ollama.com/) con el modelo `mistral` descargado (`ollama run mistral`).
- Para ejecución en la nube: Una API Key válida de OpenAI configurada en las variables de entorno.

## 🤝 Contribuciones (Dejar tu Legado)

¡Las contribuciones son más que bienvenidas! Si deseas ayudar a limpiar el código, implementar principios SOLID más estrictos, o añadir soporte para nuevos formatos de diagramas (UML, diagramas de flujo, etc.):

1. Haz un Fork del proyecto.
2. Crea una rama para tu mejora (`git checkout -b feature/MejoraArquitectura`).
3. Sube tus cambios (`git commit -m 'Refactorizar componente X aplicando SOLID'`).
4. Envía un Pull Request.

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - siéntete libre de usarlo, modificarlo y distribuirlo comercialmente.
