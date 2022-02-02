---
name: Script submit
about: Submit a script to add to the collection of scripts available by default
title: "[SCRIPT]"
labels: enhancement
assignees: ''

---

** Summary of what your script does **

** Why should/shouldn't the average run this script ? **

** How long may executing this script take ? **

** (Optional) Any additional information **

Script XML code :
```xml
<?xml version="1.0" encoding="Unicode"?>
<Script>
  <Name>
    <lcid127>EnglishName</lcid127>
  </Name>
  <Description>
    <lcid127>EnglishDescription</lcid127>
  </Description>
  <!-- Choose one -->
  <Advised>Yes/No/Limited</Advised>
  <!-- Choose one -->
  <Extension>.cmd/.bat/.reg/.ps1</Extension>
  <!-- Choose one -->
  <Impact>Ergonomics/FreeStorageSpace/MemoryUsage/NetworkUsage/Privacy/Performance/ShutdownTime/StartupTime/StorageSpeed/Visuals</Impact>
  <Code>code</Code>
</Script>
```
