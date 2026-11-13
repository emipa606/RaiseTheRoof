## Raise The Roof (Continued) Mod

### Overview

Raise The Roof (Continued) is an update of the Machines mod for RimWorld, based on the 1.5 version by Greysuki. The mod allows players to build various types of thick roofs that offer protection against drop pods, mortars, and tornadoes. It also adds the ability to remove overhead mountains through research and provides a variety of options for enabling/disabling auto roof building, power outputs, and roof cost adjustment sliders. The mod is compatible with existing save games and includes performance improvements with solar generating roofs.

### Key Features and Systems

- **Roof Types**: Players can build different types of roofs such as Steel, Solar, Transparent, and Transparent Solar. Each roof type has its own requirements and provides different benefits.
- **AreaBuildRoof and AreaRemoveRoof Area Zones**: Players can select different roof types and see the colored draw area of all different roof types. They can also select green to build constructed roof area and red to remove constructed roof area.
- **Option Settings**: Players can enable/disable auto roof building, power outputs, and roof cost adjustment sliders.
- **Compatibility**: The mod is compatible with existing save games and can be removed without issues.
- **Performance Improvements**: The mod includes performance improvements with solar generating roofs.

### Coding Patterns and Conventions

- **C# Files**: The mod includes 46 C# files, with each file containing a specific Harmony patch or function.
- **XML Files**: The mod includes 8 XML files, with each file containing specific definitions for ResearchProjectDefs, RoofDefs, ThingDefs, and Patches.
- **Naming Conventions**: The mod follows standard naming conventions for classes, methods, and variables.

### XML Integration

The mod integrates with XML files to define different types of roofs, research projects, and things. The XML files are located in the "Defs" folder and are used to define the properties and behavior of different objects in the game. The mod also includes a "Patches.xml" file that defines the Harmony patches used by the mod.

### Harmony Patching

The mod uses Harmony for easy detours, allowing for the modification of game code without altering the original codebase. The mod includes several Harmony patches, such as Area_NoRoof_Color, Area_BuildRoof_Color, AutoBuildRoofAreaSetter_TryGenerateAreaNow, DebugToolsGeneral_Kill, and Designator_AreaBuildRoof_SelectedUpdate. These patches modify various aspects of the game, such as roof selection, area zoning, and power generation.

### Suggestions for Copilot

- **Harmony Patching**: Use Harmony patches to modify game code without altering the original codebase. This can be useful for adding new features or modifying existing behavior.
- **XML Integration**: Use XML files to define different types of roofs, research projects, and things. This can be useful for adding new objects to the game or modifying existing ones.
- **Coding Patterns and Conventions**: Follow standard naming conventions for classes, methods, and variables. This can make the code more readable and maintainable.
- **Performance Improvements**: Consider performance improvements for features such as solar generating roofs. This can make the game run smoother and more efficiently.
- **Compatibility**: Ensure compatibility with existing save games and other mods. This can prevent issues when players try to remove the mod or install other mods.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

