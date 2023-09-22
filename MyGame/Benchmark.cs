using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Rendering;
using Stride.Physics;


namespace MyGame
{
    public class Benchmark : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        private readonly Random random = new Random();
        private Prefab prefab;
        private int instanceCount = 0;
        
        public override void Start()
        {
            
            
            
            prefab = Content.Load<Prefab>("CubePrefab");
            
            
            
         
        }

        public override void Update()
        {
            
            DebugText.Print($"Instance count: {instanceCount}",new Int2(10,10));
            DebugText.Print($"FPS: {Game.UpdateTime.FramePerSecond}",new Int2(10,25));
            
            if(Input.IsKeyPressed(Stride.Input.Keys.T))
            {
                SpawnGroup();
            }
            
        }
        
        public void SpawnGroup()
        {
            for(int i = 0; i < 100; i++)
            {
                SpawnInstance();
            }
        }
        
        public void SpawnInstance()
        {
        
            
            var prefabInstance = prefab.Instantiate();
            var randomPosition = new Vector3(random.Next(-20,20),4,random.Next(-20,20));
            var e = new Entity("prefab",randomPosition);
            foreach(var ent in prefabInstance)
            {
                e.AddChild(ent);
            }
            
            Entity.Scene.Entities.Add(e);
            instanceCount++;
            
            
        }
    }
}
