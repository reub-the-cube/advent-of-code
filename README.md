# advent-of-code

## Pre-reqs

- Local NuGet source containing the `AoC.Core` package. Run `.\update-scaffolding.ps1`, see 'Project scaffolding for a new day' below for more details.

## Run what you've got

From the `.\AoC.Console\` directory
- Run today's challenges
``` shell
dotnet run --today
```

- Run all challenges
``` shell
dotnet run --all
```

- Run a year's worth of challenges
``` shell
dotnet run --year ####
```

- Run a specific day's challenges
``` shell
dotnet run --year #### --day ##
```

- Choose a year and day through the shell, and repeat
``` shell
dotnet run
```

## Project scaffolding for a new day

The `.\Scaffolding` directory contains:
- An `AoC.Core` directory which contains files that are shared between days and challenges and takes the form of a `AoC.Core` NuGet package
- A template directory which contains a template called `aoc-dayx`, which can be used for setting up a new day

From the root directory, you will need to run `.\update-scaffolding.ps1` if you want to:
- Add a new day for the first time (so the NuGet gets published and the dotnet template gets installed)
- Make changes to the NuGet (the new version should be updated in the `day.csproj` too)
- Make changes to the custom template

This file will:
- Optionally try to pack and push the version specified of the NuGet
- Install the latest version of the custom template
- TODO: remove hard-coding for local NuGet feed

## Add a new day

Before you can add a new day for the first time, you need to install a dotnet template locally, as above.

Then, from the root directory, run `.\add-new-day.ps1 -year #### -day ##`. This will:
- Create *empty* files for the day's input (one for tests, one for submission)
- Create a solution file for the year if it doesn't exist
- Create a project from the `aoc-dayx` dotnet template
- Create a test project using the xunit framework
- Add the projects to the year's solution file
- Add some boilerplate test code and install missing packages
- Replace some `DayX` code with more appropriate names
