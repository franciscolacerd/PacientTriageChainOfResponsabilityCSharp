# Pacient Triage - Chain Of Responsability Pattern - C#
Chain of Responsability Pattern implementation of an Hospital Triage System

In this example, HeartAttackHandler checks if the patient has both "Chest pain" and "Numbness in arm" to identify a possible heart attack. If these symptoms are present, the wristband is set to red. Otherwise, evaluation continues with the next handler in the chain.

------

In object-oriented design, the chain-of-responsibility pattern is a behavioral design pattern consisting of a source of command objects and a series of processing objects. Each processing object contains logic that defines the types of command objects that it can handle; the rest are passed to the next processing object in the chain. A mechanism also exists for adding new processing objects to the end of this chain.

![Chain_of_Responsibility_Design_Pattern_UML](https://upload.wikimedia.org/wikipedia/commons/6/6a/W3sDesign_Chain_of_Responsibility_Design_Pattern_UML.jpg)

https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern

------

## C# Implementation

### 1. Declare Hospital entities 

#### Pacient
```c#
   public class Pacient
   {
       public string Name { get; private set; }
  
       public int Age { get; private set; }
  
       public string HealthUserNumber { get; private set; }
  
       public List<string> Symptoms { get; private set; }
  
       public BloodPressure BloodPressure { get; private set; }
  
       public double Temperature { get; private set; }
       public bool RequiresHospitalization { get; private set; }
  
       public Bracelet Bracelet { get; private set; }
  
       public Pacient(string name, int age)
       {
           Name = name;
  
           Age = age;
       }
  
       public void DoCheckin(string healthUserNumber)
       {
           this.HealthUserNumber = healthUserNumber;
       }
  
       public void AddSymptoms(List<string> symptoms, BloodPressure bloodPressure, double temperature)
       {
           this.Symptoms = symptoms;
           this.BloodPressure = bloodPressure;
           this.Temperature = temperature;
       }
  
       public void MustRequireHospitalization(bool requiresHospitalization)
       {
           this.RequiresHospitalization = requiresHospitalization;
       }
  
       public void DefineBracelet(Bracelet bracelet)
       {
           this.Bracelet = bracelet;
       }
   }
```

#### Nurse
```c#
   public class Nurse
   {
       private readonly EvaluationChainHandler _chain;
  
       public Nurse(EvaluationChainHandler chain)
       {
           this._chain = chain;
       }
  
       public void EvaluateSymptoms(Pacient pacient)
       {
           this._chain.EvaluateSymptoms(pacient);
       }
   }
```
...Bracelet, Symptoms, BloodPressure.

### 2. Declare the handler interface
```c#
    public interface ISymptomHandler
    {
        void HandleSymptom(Pacient pacient);
    }
```

### 3. Declare concrete handler subclasses

#### HearthBurnHandler
```c#
   public class HearthBurnHandler : ISymptomHandler
   {
       private readonly ISymptomHandler _nextHandler;
  
       public HearthBurnHandler(ISymptomHandler nextHandler)
       {
           _nextHandler = nextHandler;
       }
  
       public void HandleSymptom(Pacient pacient)
       {
           if (pacient.Symptoms.Count == 1 &&
               pacient.Symptoms.Contains(Symptoms.ChestPain))
           {
               pacient.DefineBracelet(Bracelet.Yellow);
           }
           else
           {
               this._nextHandler.HandleSymptom(pacient);
           }
       }
   }
```

#### HearthAttackHandler
```c#
  public class HearthAttackHandler : ISymptomHandler
  {
      private readonly ISymptomHandler _nextHandler;
  
      public HearthAttackHandler(ISymptomHandler nextHandler)
      {
          this._nextHandler = nextHandler;
      }
  
      public void HandleSymptom(Pacient pacient)
      {
          if (pacient.Symptoms.Contains(Symptoms.ChestPain) &&
              pacient.Symptoms.Contains(Symptoms.NumbnessInArm))
          {
              pacient.DefineBracelet(Bracelet.Red);
          }
          else
          {
              this._nextHandler.HandleSymptom(pacient);
          }
      }
  }
```

### 4. Declare chain handler

#### EvaluationChainHandler
```c#
    public class EvaluationChainHandler
    {
        private readonly ISymptomHandler _chain;

        public EvaluationChainHandler()
        {
            _chain = new HearthBurnHandler(new HearthAttackHandler(new DefaultHandler()));
        }

        public void EvaluateSymptoms(Pacient pacient)
        {
            _chain.HandleSymptom(pacient);
        }
    }
```

### 5. Unit test it (NUnit)

```c#
 public class PacientTriageUnitTests
 {
     private Pacient _pacient;

     private BloodPressure _bloodPressure;

     private double _temperature;

     [SetUp]
     public void Setup()
     {
         this._pacient = new Pacient("francisco lacerda", 45);

         this._pacient.DoCheckin("123456789");

         this._bloodPressure = new BloodPressure(120, 80);

         this._temperature = 37.1;
     }

     [Test]
     public void Should_HandleHeartBurn_DefineBraceletYellow()
     {
         // Arrange
         var symptoms = new List<string>
         {
             Symptoms.ChestPain
         };

         this._pacient.AddSymptoms(symptoms, this._bloodPressure, this._temperature);

         var nurse = new Nurse(new EvaluationChainHandler());

         // Act
         nurse.EvaluateSymptoms(this._pacient);

         // Assert
         this._pacient.Bracelet.Should().Be(Bracelet.Yellow);
     }

     [Test]
     public void Should_HandleHeartAttack_DefineBraceletRed()
     {
         // Arrange
         var symptoms = new List<string>
         {
             Symptoms.ChestPain,
             Symptoms.NumbnessInArm
         };

         this._pacient.AddSymptoms(symptoms, this._bloodPressure, this._temperature);

         var nurse = new Nurse(new EvaluationChainHandler());

         // Act
         nurse.EvaluateSymptoms(this._pacient);

         // Assert
         this._pacient.Bracelet.Should().Be(Bracelet.Red);
     }
 }
```

