# Copilot Instructions for Raise The Roof (Continued) Mod Development

## Mod Overview and Purpose

**Raise The Roof (Continued)** is a mod that introduces a variety of robust roof types in RimWorld, enhancing gameplay by offering players options for protection against drop pods, mortars, and tornadoes. These roofs balance the need for defense with other benefits like power generation, adding strategic depth to construction choices within the game.

## Key Features and Systems

- **Various Roof Types:**
  - **Steel Roof:** Requires 50 steel.
  - **Solar Roof:** Requires research, 50 steel, 1 component, and provides 50 watts of power.
  - **Transparent Roof:** Requires research, 50 steel, and 10 synthread.
  - **Transparent Solar Roof:** Requires research of other roofs, 50 steel, 10 synthread, 1 component, and provides 50 watts of power.
  
- **Custom Roof Zoning:** Highlight different roof types with colors:
  - Orange for Overhead Mountain
  - Yellow for Thin Rock Roof
  - Cyan for Constructed Roof
  - Blue for Constructed Steel Roof
  - Teal for Constructed Solar Roof
  - Pink for Constructed Transparent Roof
  - Purple for Constructed Transparent Solar Roof

- **Area Management:**
  - Green for Build Constructed Roof Area
  - Red for Remove Constructed Roof Area

- **Research Mechanic to Remove Overhead Mountain**

- **Settings for Customization:**
  - Options to enable/disable auto roof building.
  - Adjust power outputs and costs of roofs.

- **Compatibility Note:** 
  - Advisable not to use with other roof-building mods due to potential conflicts.
  - Compatible with existing save games, but it's recommended to remove mod roofs before uninstalling.

## Coding Patterns and Conventions

- The mod employs typical C# OOP patterns, with classes extending base RimWorld functionality:
  - `Building_SolarArray` and related classes manage new roof functionalities.
  - Classes in `CompBuildCustomRoof.cs` and `CompRemoveCustomRoof.cs` extend ThingComp to modify roof behaviors.

- **Naming Conventions:** Classes and methods follow the PascalCase convention.

- **Modular Code Structure:** Each file corresponds to a specific aspect of the mod, such as building, comp, patching, and utility classes.

## XML Integration

- XML files define various configurations, such as research prerequisites, roof costs, and type mappings.
- Ensure XML tags and attributes are consistent with RimWorld's expected schema.

## Harmony Patching

- Extensive use of Harmony for modifying existing game behavior through detours:
  - `Patches.cs` contains multiple internal static classes for patch functions, hooking into core functionality like construction designations and light overlays.

- **Common Patches:**
  - `Patch_GlowGrid_GameGlowAt` and `Patch_SectionLayer_LightingOverlay_Regenerate` modify how light interacts with the new roof types.
  - `Patch_RoofGrid_SetRoof` and `Patch_GenConstruct_CanConstruct` ensure proper roof placement and compatibility checks.

## Suggestions for Copilot

- **Boilerplate Code Generation:**
  - Use Copilot to draft common patterns like class definitions and method stubs for new features.

- **Code Comments and Documentation:**
  - Leverage Copilot to add XML comment templates and method annotations for better code readability and maintenance.

- **Harmony Patch Facilitation:**
  - Suggest potential new patches to enhance compatibility with future RimWorld updates or new gameplay features.

- **Performance Improvements:**
  - Use Copilot to identify opportunities for optimization, particularly in areas like redundant operations in solar power generation.

Ensure each component of your mod is well-documented, both in code comments and in this instruction file, to aid collaboration and future updates.
