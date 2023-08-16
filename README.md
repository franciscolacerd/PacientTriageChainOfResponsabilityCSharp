# Pacient Triage Chain Of Responsability
Chain of Responsability implementation of an Hospital Triage System

In this example, HeartAttackHandler checks if the patient has both "Chest pain" and "Numbness in arm" to identify a possible heart attack. If these symptoms are present, the wristband is set to red. Otherwise, evaluation continues with the next handler in the chain.

------

In object-oriented design, the chain-of-responsibility pattern is a behavioral design pattern consisting of a source of command objects and a series of processing objects.[1] Each processing object contains logic that defines the types of command objects that it can handle; the rest are passed to the next processing object in the chain. A mechanism also exists for adding new processing objects to the end of this chain.

https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern

![Chain_of_Responsibility_Design_Pattern_UML](https://upload.wikimedia.org/wikipedia/commons/6/6a/W3sDesign_Chain_of_Responsibility_Design_Pattern_UML.jpg)
