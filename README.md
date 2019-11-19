# Prérequis

* Installer Visual Studio Code
* Installer .net Core SDK 3.0.100 :
  https://dotnet.microsoft.com/download
  et tester avec `dotnet --version`  
* Installer un terminal 'sérieux' (Terminus, cmder...)
* Installer `git` et tester avec `git --version` 
* Dossier de travail : `Isen.Dotnet`  
* Ouvrir ce dossier depuis un terminal : cd (...) puis `code .`  
* Créer `README.md` (ce fichier)

# Préparation de la solution

## En faire un repository git
* `git init` afin d'initialiser le dossier comme repo git
* Créer un fichier `.gitignore`  avec `touch .gitignore`  
* Prendre sur internet un modèle de .gitignore
  adapté à c# / .net

## Créer un remote et push le projet
* Sur Github / GitLab (ou autre), créer un repo remote pour ce projet.  
* Ajouter ce remote comme upstream du repo local :
`git remote add origin https://github.com/kall2sollies/Isen2019-11`  
* commit initial du projet :
  `git add .`  
  `git commit -m "initial commit"`  
  `git push origin master`  

## Créer un premier projet (console)
  * Dans le dossier de travail, créer un dossier `src/Isen.Dotnet.ConsoleApp`.
  * Naviguer dans ce dossier dans le terminal. 
  * Créer un projet console en utilisant la `CLI` dotnet  (Command Line Interface) avec la commande :
  `dotnet new console`  
  * tester avec `dotnet run` 

## Architecture d'une solution (workspace) donet
* `Isen.Dotnet` est le nom de la solution (workspace) et  en même temps la racine de tous les namespace.
* `Isen.Dotnet.ConsoleApp` est un **projet**.  Son nom correspond au `namespace` du projet, lui-même étant hiérarchiquement imbriqué au namespace de la solution.
* Le fichier projet a l'extension `.csproj`. C'est un fichier xml qui décrit :
  * Le type de projet
  * Ses dépendances
  * Le runtime utilisé
* Le workspace / solution dispose d'un fichier de solution, qui recence tous les projets de la solution, ainsi que les fichiers annexes (type readme, gitignore...). Ce fichier est de type `.sln` et va être créé ainsi :

Depuis le dossier racine (Isen.Dotnet)
`dotnet new sln`  (Ceci crée simplement le fichier sln)  
`dotnet sln add src\Isen.Dotnet.ConsoleApp\` (Ceci ajoute le projet console au référentiel que constitue le sln).

## Création du projet Library

* Sous src/ créer un dossier `Isen.Dotnet.Library` et naviguer dedans avec le terminal.  
* Lancer la commande `dotnet new classlib`  
* Supprimer `Class1.cs`  
* Revenir à la racine du projet, et référencer ce nouveau projet dans le sln :
  `dotnet sln add src\Isen.Dotnet.Library\`  
* Ajouter ce projet (library) comme référence du projet console. De cette manière, le projet console pourra utiliser des classes codées dans le projet Libray. Depuis le dossier src/Isen.Dotnet.ConsoleApp, lancer :
  `dotnet add reference ..\Isen.Dotnet.Library\`  

## Vérifications
La hiérarchie est :
* Isen.DotNet/ (sln)
  * src/
    * Isen.DotNet.ConsoleApp/ (csproj)
    * Isen.DotNet.Library/ (csproj)
  * README.md

  Le fichier sln doit contenir des références aux 2 projets (ConsoleApp et Library).  

  Le fichier src/Isen.DotNet.ConsoleApp/Isen.DotNet.ConsoleApp.csproj doit contenir une référence à Library.

# Le C#

## Créer une classe Hello
Dans le projet Library, créer Hello.cs. :
* using, namespace, class
* Propriété avec accesseur implicite
* Constructeur
* Méthode Greet()

Dans le projet console, instancier la classe Hello (il faut un using) et envoyer la sortie de la méthode Greet vers la console.  

## Création d'une classe de Liste
Dans Library, créer MyCollection.cs et ajouter les déclarations d'une classe C#. (on peut dupliquer Hello).

Le but de cette classe est de créer et manipuler une liste de string (ajout, suppression, etc...).  
On va utiliser un tableau natif (`string []`) comme structure de stockage interne de la liste.  

### Base de la classe
* Ajouter un tableau natif privé, pour le stockage de la liste.
* Constructeurs :
  * Initialisation du tableau
  * Surcharge avec tableau en paramètre
* Affichage : override de ToString, construction d'une chaine avec tous les éléments en utilisant `StringBuilder`
* Tester cet état de la classe dans le projet console.

### Méthode Add(item)
Cette méthode ajoute un élément passé en argument à la fin de la liste.  
Coder cette méthode. La tester.

### Méthode RemoveAt(index)
Cette méthode retire l'élément situé à l'index passé en argument. Index 0-based.  
Coder cette méthode. La tester.

### Méthode IndexOf(item)
Cette méthode renvoie l'index 0-based de l'élément passé en argument (ou le premier, si l'élément y est plusieurs fois).  
Coder cette méthode. La tester.  

### Accesseur / indexeur
Coder l'accesseur qui va permettre d'accéder au valeur de la liste comme si c'était un tableau primitif :
`myCollection[3]`  
Réécrire dans les autres méthodes tous les appels `_values[i]` qui deviennent `this[i]`.  

### Ajout d'un projet de tests unitaires

* Créer un dossier `tests/` au niveau de `src/` (donc à la racine) 
* Dans ce dossier, créer `Isen.Dotnet.UnitTests/` et naviguer dedans avec le terminal.
* Créer le projet de tests avec `dotnet new xunit`
* Référencer Library dans le projet de tests : 
  `dotnet add reference ../../src/Isen.Dotnet.Library`
* Ajouter le projet de tests au fichier sln : depuis la racine du projet : `dotnet sln add tests/Isen.Dotnet.UnitTests/`
* Renommer la classe `UnitTest1` en `MyLibraryStringTests`
* Ecrire 2 tests bidon (un qui réussit, un qui plante)
* Lancer les tests, depuis le répertoire du projet de tests, avec `dotnet test`  

### Ajout de méthodes de tests unitaires

* Créer 2 méthodes statiques pour générer un tableau primitif de référence, et une liste créée à partir de ce tableau.
* Tester `Count()` en vérifiant que les 2 dimensions sont les mêmes (`Assert.Equal()`).
* Dans la classe MyCollection, ajouter un getter pour rendre Values visible.
* Tester `Add()` en utilisant le `Assert.Equal(array, array)`  
* Tester 'IndexOf()` au début, au milieu, à la fin
* Tester l'accesseur indexeur `this[index]` au début, au milieu, à la fin.
* Tester `RemoveAt()` en comparant les états successifs de la liste avec des arrays statiques qui representent les états attendus.

### Méthode Remove(item)
Cette méthode prend un item en paramètre, et retire cet élément de la liste si elle le trouve. S'il y en plusieurs, elle retire le premier. S'il n'y en a pas, elle ne fait rien.
La méthode renvoie un bool selon qu'elle a retiré ou non l'élément.
Coder ceci en TDD = Test Driven Development (Prototype, test, implémentation).

### Méthode Insert(index, item)
Cette méthode insère l'item à l'index donné, et décale les éléments suivants.  
Ex : `"A", "B", "D"` => `Insert(2, "C")` => `"A", "B", "C", "D"`.  
