using System;
using System.Collections.Generic;
using System.Text;

namespace znamkamarada.Services.Library.ModelsDto
{
    public class VignetteValidationResult
    {
        public DateTime validatedOnUtc { get; set; }
        public bool isValid { get; set; }
    }
}
