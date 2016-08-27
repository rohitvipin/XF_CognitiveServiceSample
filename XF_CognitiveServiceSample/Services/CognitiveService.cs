using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using System.Collections.Generic;
using Microsoft.ProjectOxford.Vision.Contract;

namespace XF_CognitiveServiceSample.Services
{
    public class CognitiveService
    {
        const string _subscriptionKey = "a3c516cf3b9d4e489c164c99d16cab04";

        public async Task<AnalysisResult> GetImageDetailsAsync(Stream imageStream)
        {
            var visionClient = new VisionServiceClient(_subscriptionKey);
            var features = new List<VisualFeature>
                            {
                                VisualFeature.Tags, 
                                VisualFeature.Categories,
                                VisualFeature.Description,
                                VisualFeature.Adult,
                                VisualFeature.Color,
                                VisualFeature.ImageType
                            };
            return await visionClient.AnalyzeImageAsync(imageStream, features, null);
        }
    }
}

