﻿namespace Tvl.VisualStudio.Language.Java.Debugger.Analysis
{
    public enum JavaStackBehavior
    {
        Pop0,
        Pop1,
        Pop1_Pop1,
        PopI,
        PopI_PopI,
        PopI8,
        PopI8_PopI8,
        PopI8_PopI,
        PopR4,
        PopR4_PopR4,
        PopR8,
        PopR8_PopR8,
        PopRef,
        PopRef_Pop1,
        PopRef_PopI,
        PopRef_PopI_PopI,
        PopRef_PopI_PopI8,
        PopRef_PopI_PopR4,
        PopRef_PopI_PopR8,
        PopRef_PopI_PopRef,
        PopRef_PopRef,
        PopVar,

        Push0,
        Push1,
        Push1_Push1,
        PushI,
        PushI8,
        PushR4,
        PushR8,
        PushRef,
        PushRet,
        PushVar,
    }
}