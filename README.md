## DI implementation:

BindManager - DI container

<br><br><br><br>
## Architecture:

* AppRoot - main entry point
* Mediators - classes that are contained logic
* BaseView, BaseComponent - view classes
* IDataContext - view data


UIConfig – store information about UI prefabs
PrefabReferences – store references to prefabs
MatchLogic - field logic (matches, field generation)

Connection between logic and view are made buy LogicActions that transferred and mapped to
Handlers:
* ElementDestroyLogicAction -> DestroyActionHandler


<br><br><br><br>
## Editor:
Assets/Resources/Configs/Levels
In this folder you can find level configs
To change tile status - click on tile
“Green o” - open tile
“Black” - tile will be visible but locked for elements, you can’t put elements on this tile
“Transparent” - tile will be ignored by game

<br><br><br><br>
## Knowing issues:
Sometimes you can't match elements


<br><br><br><br>
## Technical depth:
* Field generation algorithm
* Match algorithm
