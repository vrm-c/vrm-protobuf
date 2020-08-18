using System;
using System.IO;
using System.Linq;
using VrmValidator;
using Xunit;

namespace ValidatorTests
{
    public class VrmTests
    {
        [Theory]
        [InlineData("Models/Alicia_051/AliciaSolid_vrm-0.51.vrm")]
        [InlineData("Models/Cecil/Cecil.vrm")]
        [InlineData("Models/CustomCast/20180820/CC-20180820.vrm")]
        [InlineData("Models/ILtan/ILtan_use_everyone_jp.vrm")]
        [InlineData("Models/Miraikomachi/Miraikomachi.vrm")]
        [InlineData("Models/NiconiSolid/Alicia_Voxel/Voxel_alicia_voxel.vrm")]
        // [InlineData("Models/NiconiSolid/droid-vrm/droid-vrm.vrm")] // 0.30
        [InlineData("Models/NiconiSolid/hackadoll_1/hackadoll_1.vrm")]
        [InlineData("Models/NiconiSolid/hackadoll_2/hackadoll_2.vrm")]
        [InlineData("Models/NiconiSolid/hackadoll_3/hackadoll_3.vrm")]
        // [InlineData("Models/NiconiSolid/Nanashi/nanasi_VRM.vrm")] // 0.30
        [InlineData("Models/NiconiSolid/OrigishiMitu/折岸みつ.vrm")]
        [InlineData("Models/NiconiSolid/PronamaChan/PronamaChan.vrm")]
        [InlineData("Models/NiconiSolid/VJ_TAKAGI/vj_takagi.vrm")]
        [InlineData("Models/Seedsan/seedsan_v1_0_2.vrm")]
        [InlineData("Models/UnityChan/unitychan.vrm")]
        [InlineData("Models/VRoid/VictoriaRubin/VictoriaRubin.vrm")]
        [InlineData("Models/V_Katsu/Machine/小町 まちね.vrm")]
        [InlineData("Models/V_Katsu/Shogun/ナイトショーグン.vrm")]
        public void VrmTestModelsTest(string file)
        {
            var path = Path.Combine(System.Environment.GetEnvironmentVariable("VRM_TEST_MODELS"), file);
            var context = VrmValidator.Validator.Validate(path);

            var filtered = context.Messages
                .Where(x => !x.JsonPath.Contains(".extras."))
                .Where(x => !x.JsonPath.Contains(".extra"))
                .Where(x => !x.JsonPath.Contains(".VRM.Version"))
                .Where(x => x.MessageType != MessageTypes.MinimumException)
                .ToArray();

            Assert.Empty(filtered);
        }
    }
}
