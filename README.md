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