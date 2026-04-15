# PC_F (Processor Control Framework) 🚀

**PC_F** es un motor de bajo nivel diseñado para interactuar directamente con los registros del procesador (MSR - Model Specific Registers). Actúa como el "músculo" del sistema, ejecutando cambios de frecuencia, voltajes y multiplicadores en tiempo real.

## 🛠 Características Técnicas
- **Ring 0 Access:** Interacción directa con el hardware mediante controladores de bajo nivel.
- **MSR Manipulation:** Capacidad de lectura y escritura de registros específicos del procesador para control térmico y de rendimiento.
- **Arquitectura Slave:** Diseñado para recibir instrucciones externas mediante argumentos de línea de comandos, permitiendo una integración transparente con interfaces de usuario.
- **Optimización de Recursos:** Escrito en C# con un enfoque en el mínimo uso de ciclos de CPU para no interferir en pruebas de rendimiento o juegos.

## 🚀 Uso
PC_F no requiere configuración manual por parte del usuario, ya que está optimizado para ser controlado por **PlusControl**. No obstante, admite comandos directos para depuración técnica.

---
*Desarrollado por Breniak - Enfoque en Ingeniería de Bajo Nivel.*
