[![NuGet Downloads][nuget-shield]][nuget-url][![Contributors][contributors-shield]][contributors-url][![Forks][forks-shield]][forks-url][![Stargazers][stars-shield]][stars-url][![Issues][issues-shield]][issues-url][![License][license-shield]][license-url][![LinkedIn][linkedin-shield]][linkedin-url]

# ![Logo][logo] Menu paginator

Pagination Lib for menu selection in C# console applications.

[![screenshot 1][screenshot1]][screenshot1-url] [![screenshot 2][screenshot2]][screenshot2-url] [![screenshot 3][screenshot3]][screenshot3-url]

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
    - [Install via NuGet Package Manager Console](#install-via-nuget-package-manager-console)
    - [Install via Visual Studio NuGet Package Manager](#install-via-visual-studio-nuget-package-manager)
    - [Install via .NET CLI](#install-via-dotnet-cli)
    - [Clone the repo](#clone-the-repo)
  - [Example Usage](#example-usage)
- [Example](#example)
- [Contributing](#contributing)
    - [Translation](#translation)
- [License](#license)
- [Contact](#contact)
- [Acknowledgments](#acknowledgments)

## Overview

The Menu Paginator library is a C# library that provides a simple and efficient way to create paginated menus in console applications. It allows you to display a list of menu items in a paginated format, making it easy for users to navigate through lists of menu choice.
 
## Features
- [x] Pagination: The library allows you to paginate a list of menu items, making it easy to navigate through large lists.
- [x] Customizable: You can customize the appearance of the menu, including colors, styles, and more.
- [x] Keyboard Navigation: The library supports F1-F10 for select menu.
- [x] Easy to Use: The library is easy to use and integrate into your existing console applications.
- [x] Multi-language support: The library can support multiple languages, making it easy to use in different regions.
- [x] Example: The library comes with an example project that demonstrates how to use the library.
- [x] Open Source: The library is open source and available on GitHub, allowing you to contribute and improve the library.

## Getting Started

This section will guide you through the installation and setup of the Menu Paginator library in your C# console application.

### Prerequisites

- .NET 9.0 or later

### Installation

You can install this library using NuGet Package Manager or by adding the package reference directly to your project file. The library is available on NuGet, so you can easily install it using the NuGet Package Manager Console or the Visual Studio NuGet Package Manager.

#### Install via NuGet Package Manager Console

You can install this library using the NuGet Package Manager Console. Open the console and run the following command:
```bash
Install-Package TirsvadCLI.MenuPaginator
```

#### Install via Visual Studio NuGet Package Manager

You can also install this library using the Visual Studio NuGet Package Manager. Follow these steps:

1. Open your project in Visual Studio.
2. Right-click on your project in the Solution Explorer and select "Manage NuGet Packages".
3. Search for "TirsvadCLI.MenuPaginator" in the NuGet Package Manager.
4. Click "Install" to add the library to your project. 

#### Install via .NET CLI

You can also install this library using the .NET CLI. Open a terminal and run the following command:
```bash
dotnet add package TirsvadCLI.MenuPaginator
```

#### Clone the repo

![Repo size][repos-size-shield]

If you want to clone the repository and build the library from source, you can do so using Git. Make sure you have Git installed on your machine. Then, run the following command in your terminal:

```bash
git clone git@github.com:TirsvadCLI/Dotnet.Lib.MenuPaginator.git
```

## Example

In the [example][example] you can see how to use the Menu Paginator class.

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Translation

We need help for translate to other languages. If you want to help, please create a new issue with the translation. We will add it to the project.

Resources.resx contains the msg that can be translated. The key text is English.

For now we have the following languages:
- da (Danish)
- en (English)
- ms (Malay)

If can create a new file called Resources.\<language\>.resx, where \<language\> is the language code. For example, for Danish, the file should be called Resources.da.resx. The file should contain the same keys as the original file, but with the translated text.

![Translation][translation]

## License

Distributed under the GPL-3.0 [License][license-url].

## Contact

Jens Tirsvad Nielsen - [LinkedIn][linkedin-url]

## Acknowledgments

<!-- MARKDOWN LINKS & IMAGES -->
[contributors-shield]: https://img.shields.io/github/contributors/TirsvadCLI/Dotnet.Lib.MenuPaginator?style=for-the-badge
[contributors-url]: https://github.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/TirsvadCLI/Dotnet.Lib.MenuPaginator?style=for-the-badge
[forks-url]: https://github.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/network/members
[stars-shield]: https://img.shields.io/github/stars/TirsvadCLI/Dotnet.Lib.MenuPaginator?style=for-the-badge
[stars-url]: https://github.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/stargazers
[issues-shield]: https://img.shields.io/github/issues/TirsvadCLI/Dotnet.Lib.MenuPaginator?style=for-the-badge
[issues-url]: https://github.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/issues
[license-shield]: https://img.shields.io/github/license/TirsvadCLI/Dotnet.Lib.MenuPaginator?style=for-the-badge
[license-url]: https://github.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/jens-tirsvad-nielsen-13b795b9/
[githubIssue-url]: https://github.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/issues/
[repos-size-shield]: https://img.shields.io/github/repo-size/TirsvadCLI/Dotnet.Lib.MenuPaginator?style=for-the-badg

[nuget-shield]: https://img.shields.io/nuget/dt/TirsvadCLI.MenuPaginator?style=for-the-badge
[nuget-url]: https://www.nuget.org/packages/TirsvadCLI.MenuPaginator/

[logo]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/master/image/logo/32x32/logo.png

[screenshot1]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/master/image/small/Screenshot1.png
[screenshot1-url]: https://github.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/blob/main/image/Screenshot1.png
[screenshot2]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/master/image/small/Screenshot2.png
[screenshot2-url]: https://github.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/blob/main/image/Screenshot2.png
[screenshot3]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/master/image/small/Screenshot3.png
[screenshot3-url]: https://github.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/blob/main/image/Screenshot3.png

[translation]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/master/image/Translation.png

[example]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/master/src/Example/Example.cs
[example-screenshot]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Lib.MenuPaginator/master/src/image/Example.png
