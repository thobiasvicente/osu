﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Game.Screens.Select
{
    public class EditSongSelect : SongSelect
    {
        protected override bool ShowFooter => false;

        protected override bool OnStart()
        {
            Exit();
            return true;
        }
    }
}
