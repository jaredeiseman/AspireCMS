using AspireCMS.ApiService.Contexts;
using AspireCMS.Entities;
using AspireCMS.Enums;
using AspireCMS.Interfaces;

namespace AspireCMS.ApiService.Services
{
    public class ContentBlockService : IContentBlockService
    {
        private CMSContext _context;

        public ContentBlockService(CMSContext context)
        {
            _context = context;
        }

        public async Task<ContentBlock> CreateContentBlock(BlockType blockType, string content, Guid pageId, int position)
        {
            ContentBlock newBlock = new ContentBlock()
            {
                BlockType = blockType,
                Content = content,
                PageId = pageId,
                Position = position
            };

            ShiftBlocks(position);

            _context.ContentBlocks.Add(newBlock);

            await _context.SaveChangesAsync();

            return newBlock;
        }

        public List<ContentBlock> GetContentBlocks(Guid pageId)
        {
            return _context.ContentBlocks.Where(cb => cb.PageId == pageId).OrderBy(cbs => cbs.Position).ToList();
        }

        private void ShiftBlocks(int newPosition)
        {
            var blocksToShift = _context.ContentBlocks.Where(cb => cb.Position >= newPosition);

            if (blocksToShift.Any())
            {
                foreach (var block in blocksToShift)
                {
                    block.Position++;
                }
            }
        }
    }
}
