﻿using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider;
using DbLocalizationProvider.Abstractions;

namespace MyProject
{
    [LocalizedResource]
    public class SampleResources
    {
        public static string PageHeader => "This is page header";
    }

    [LocalizedResource]
    public class ResourcesForFallback
    {
        [TranslationForCulture("Det er på norsk", "no")]
        public static string OnlyInNorwegian => "Only in Norwegian (Invariant)";

        public static string OnlyInInvariant => "Only in Invariant";

        [TranslationForCulture("In Swedish and English (SV)", "sv")]
        [TranslationForCulture("In Swedish and English (EN)", "en")]
        public static string InSwedishAndEnglishInvariant => "In Swedish and English (INV)";
    }


    public class ContainerClass
    {
        public class NestedClass
        {
            [LocalizedResource]
            public class TheResourceClass
            {
                public static string SomeKey => "Some translation";
            }
        }
    }
}

namespace DbLocalizationProvider.Core.AspNetSample.Resources
{
    [LocalizedResource]
    public class SampleResources
    {
        public static string PageHeader => "This is page header";

        public string PageHeader2 { get; set; } = "This is page header 2";

        [WeirdCustom("Weird html attribute value")]
        public static string SomeHtmlResource => "<span><b>THIS IS BOLD</b></span>";

        [WeirdCustom("Weird enum attribute value")]
        public static SomeEnum SomeEnumProperty => SomeEnum.ValueOne;

        public static string ThisIsPrettyLongResourceKeyNameJustToTestHowBadItLooksInAdministrativeUserInterfaceResourceListPageTable => "This is pretty long";
    }

    [LocalizedResource]
    public enum SomeEnum
    {
        None = 0,

        [Display(Name = "Value [1]")]
        ValueOne = 1,

        [Display(Name = "Value [2]")]
        ValueTwo = 2,

        [Display(Name = "Value [3]")]
        ValueThree = 3
    }
}
