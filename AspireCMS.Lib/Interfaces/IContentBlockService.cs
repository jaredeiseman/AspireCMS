using AspireCMS.Entities;
using AspireCMS.Enums;

namespace AspireCMS.Interfaces
{
    public interface IContentBlockService
    {
        /// <summary>
        /// Create a content block.
        /// </summary>
        /// <param name="blockType"></param>
        /// <param name="content"></param>
        /// <param name="pageId"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        Task<ContentBlock> CreateContentBlock(BlockType blockType, string content, Guid pageId, int position);

        /// <summary>
        /// Get content blocks for a given page.
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns></returns>
        List<ContentBlock> GetContentBlocks(Guid pageId);
    }
}