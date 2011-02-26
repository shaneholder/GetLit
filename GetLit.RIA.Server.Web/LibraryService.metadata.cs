
namespace GetLit.Web.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies LibraryMetadata as the class
    // that carries additional metadata for the Library class.
    [MetadataTypeAttribute(typeof(Library.LibraryMetadata))]
    public partial class Library
    {

        // This class allows you to attach custom attributes to properties
        // of the Library class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class LibraryMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private LibraryMetadata()
            {
            }

            public int LibraryId { get; set; }

            public string Name { get; set; }

            public EntityCollection<Title> Titles { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TitleMetadata as the class
    // that carries additional metadata for the Title class.
    [MetadataTypeAttribute(typeof(Title.TitleMetadata))]
    public partial class Title
    {

        // This class allows you to attach custom attributes to properties
        // of the Title class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TitleMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TitleMetadata()
            {
            }

            public Library Library { get; set; }

            public string Name { get; set; }

            public string NetflixTitleId { get; set; }

            public int TitleId { get; set; }
        }
    }
}
