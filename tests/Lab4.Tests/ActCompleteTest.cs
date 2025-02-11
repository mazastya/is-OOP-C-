﻿using System;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Input;
using System.Xml;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Exception;
using Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;
using NSubstitute;
using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles.ShowFile;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ActCompleteTest
{
    [Fact]
    public void ConnectCommand()
    {
        // Arrange
        string path1 = @"connect C:\Users\amaza\Desktop -m local";
        string[] path = path1.Split(' ');
        var parser = new ConnectFlag();

        // Act
        string ans = parser.HandleRequest(path);

        // Assert
        Assert.Equal("act complete", ans);
    }

    [Fact]
    public void DeleteCommand()
    {
        // Arrange
        string path1 = @"file delete C:\\Users\\amaza\\Desktop\\test.txt";
        string[] path = path1.Split(' ');
        var parser = new DeleteFileFlag();

        // Act
        string ans = parser.HandleRequest(path);

        // Assert
        Assert.Equal("act complete", ans);
    }

    [Fact]
    public void MoveCommandTest()
    {
        // Arrange
        string path1 = @"file move C:\\Users\\amaza\\Desktop\\test.txt C:\\Users\\amaza\\Desktop\\Study\\test.txt";
        string[] path = path1.Split(' ');
        var parser = new MoveFileFlag();

        // Act
        string ans = parser.HandleRequest(path);

        // Assert
        Assert.Equal("act complete", ans);
    }

    [Fact]
    public void NotCorrectCommand()
    {
        // Arrange
        string path1 =
            @"D:\Programs_from_installation\Rider\mazastya\src\Lab4\bin\Debug\net7.0\Folder2\Folder2_1\move_test.txt D:\Programs_from_installation\Rider\mazastya\src\Lab4\bin\Debug\net7.0\Folder1";
        string[] path = path1.Split(' ');
        var parser = new MoveFileFlag();

        // Act

        // Assert
        Assert.Throws<RequestCannotBeHandledException>(() => parser.HandleRequest(path));
    }
}