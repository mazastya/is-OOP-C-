﻿using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonDeflectors : IDeflector
{
    private readonly DeflectorBase _deflectorBase;
    private int _anountOfFlash = 3;

    public PhotonDeflectors(DeflectorBase deflectorBase)
    {
        ArgumentNullException.ThrowIfNull(nameof(deflectorBase));
        _deflectorBase = deflectorBase;
    }

    public ResultOfDamage TakeDamage(ObstacleBase obstacle)
    {
        ArgumentNullException.ThrowIfNull(nameof(obstacle));

        if (obstacle is not PhotoneFlash)
            return _deflectorBase.TakeDamage(obstacle);

        if (_anountOfFlash == 0)
        {
            return ResultOfDamage.CrewIsDead;
        }

        _anountOfFlash--;
        obstacle.TakeDamage(1000);
        return ResultOfDamage.Success;
    }
}