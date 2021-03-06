﻿using BehaviorDesigner.Runtime;
using ETModel;
using System;

namespace ETHotfix
{
    public static class BehaviorTreeFactory
    {
        public static BehaviorTree Create(string name)
        {
            string path = $"../BehaviorDesigner/{name}.json";

            try
            {
                var behavior = Behavior.Create(path);

                if(behavior != null)
                {
                    var behaviorTree = ComponentFactory.Create<BehaviorTree, Behavior>(behavior);
                    behaviorTree.AddComponent<BehaviorTreeComponent, BehaviorTree>(behaviorTree);
                    return behaviorTree;
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception($"load behavior file fail, path: {path} {e}");
            }
        }
    }
}
