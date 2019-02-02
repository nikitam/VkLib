using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Methods.Board;

namespace VkLib.Api
{
    public class Board
    {
        public static String AddTopic(IExecuteSystem es, String groupId, String title, String text = null, Boolean? fromGroup = null, List<String> attachments = null)
        {
            var method = new AddTopic
            {
                GroupId = groupId,
                Title = title,
                Text = text,
                FromGroup = fromGroup,
                Attachments = attachments
            };

            return es.Execute(method);
        }

        public static String AddComment(IExecuteSystem es, String groupId, String topicId, String text = null, List<String> attachments = null, Boolean? fromGroup = null, Int32? stickerId = null, String commentGuid = null)
        {
            var method = new AddComment
            {
                GroupId = groupId,
                TopicId = topicId,
                Text = text,
                Attachments = attachments,
                FromGroup = fromGroup,
                StickerId = stickerId,
                GuidComment = commentGuid
            };

            return es.Execute(method);
        }
    }

}