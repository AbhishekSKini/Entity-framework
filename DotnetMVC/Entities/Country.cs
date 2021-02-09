///// <autogenerated>Remove this line to stop Code Generation<autogenerated>
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Country.cs" company="BurganBank">
//   The country Entity
// </copyright>
// <summary>
//   The country Entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DotnetMVC.Entities
{
    [Table("country")]
    public class Country
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ctr_id")]
        [Display(Name = "Id")]
        public int Id
        {
            get;
            set;
        }

        /// _string_NULL_base
        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        [Column("ctr_code"), Description("Country Code"), MaxLength(200)]
        public string CountryCode
        {
            get;
            set;
        }

        /// _string_NOT_NULL_base
        /// <summary>
        /// Gets or sets the from title.
        /// </summary>
        [Column("ctr_title"), Description("Title"), Required, MaxLength(200)]
        public string Title
        {
            get;
            set;
        }
        [Column("styn_createddate"), Description("Created Date")]
        public DateTime? CreatedDate
        {
            get;
            set;
        }
        ////region CustomCodeBlock4#
        ////endregion CustomCodeBlock4#
        ////region CustomCodeBlock5#
        ////endregion CustomCodeBlock5#
    }
}