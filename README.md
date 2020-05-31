# addup-xslt

![Build](https://github.com/addupsolutions/addup-xslt/workflows/Build/badge.svg)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=addupsolutions_addup-xslt&metric=alert_status)](https://sonarcloud.io/dashboard?id=addupsolutions_addup-xslt)

## About

This repository provides a very simple tool allowing to apply an XSL transformation to an input XML file.

## Usage

```shell
$ ./xslt input.xml transform.xsl output
```

```shell
> xslt.exe input.xml transform.xsl output
```

## History

## 1.0.2

* Wired Sonarcloud analysis
* Upgraded dependencies
* Now using [GitVersion](https://github.com/GitTools/GitVersion) to automatically handle assemblies versioning

## [1.0.1](https://github.com/addupsolutions/addup-xslt/releases/tag/v1.0.1) - 2020/01/29

* Replaced [Fody/Costura](https://github.com/Fody/Costura) with [ILRepack](https://github.com/ravibpatel/ILRepack.Lib.MSBuild.Task) as the assembly merging tool for the .NET 4.7.2 build
* Fixed the .NET 4.7.2 build  (issue [#1](https://github.com/addupsolutions/addup-xslt/issues/1)).

## [1.0.0](https://github.com/addupsolutions/addup-xslt/releases/tag/v1.0.0) - 2020/01/28

**Beware: the .NET 4.7.2 build in this release is broken. See issue [#1](https://github.com/addupsolutions/addup-xslt/issues/1)**

* Initial release.

## Credits

In our in-house CI, we are using an XSL stylesheet to transform Unit Tests `.trx` files into JUnit format. To do so, we relied on Microsoft's *aging* **[msxsl.exe](https://www.microsoft.com/en-us/download/details.aspx?id=21714)** tool. Then one day, this tool ceased working. We didn't spend more than 5 minutes trying to understand what was going one and instead went on googling for a replacement.

This is when we found the [XSLTransform](https://github.com/Zoomicon/tranXform/tree/master/src/XSLTransform) project.

However:
* **XSLTransform** is written using VB.NET which is... not our prefered language, but more importantly
* It targets .NET 2.0
* Makes use of a Codeplex-hosted Nuget package, [Mvp.Xml](https://archive.codeplex.com/?p=mvpxml), also targeting the full framework.

Hopefully, **Mvp.Xml** was ported to .NET Standard here: [Mvp.Xml.NetStandard](https://github.com/keimpema/Mvp.Xml.NetStandard)

Therefore, our version of the tool is based on **Mvp.Xml.NetStandard** and targets both .NET 4.7.2 and .NET Core 3.0.

Hence, credits go to:
* [Zoomicon](https://github.com/Zoomicon) user for providing the initial tool
* The unnnamed Microsoft MVP who made **Mvp.Xml** available.
* [keimpema](https://github.com/keimpema) user for porting **Mvp.Xml** to .NET Standard.

Without them, I don't doubt we'd have succeeded in crafting a working XSL transformation tool, however it would have been more work :)

Credit also goes to [ILRepack](https://github.com/ravibpatel/ILRepack.Lib.MSBuild.Task) because we used it so that the .NET 4.7.2 version is a standalone executable!

## License

This work is provided under the terms of the [MIT License](LICENSE).
