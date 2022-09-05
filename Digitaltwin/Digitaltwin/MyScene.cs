using System;
using Evergine.Common.Graphics;
using Evergine.Components.Cameras;
using Evergine.Components.Graphics3D;
using Evergine.Framework;
using Evergine.Framework.Graphics;
using Evergine.Framework.Services;
using Evergine.Mathematics;
using Evergine.Common.Input.Mouse;
using Evergine.Framework.Assets;

namespace Digitaltwin
{
    public class MyScene : Scene
    {
        public override void RegisterManagers()
        {
            base.RegisterManagers();
            this.Managers.AddManager(new Evergine.Bullet.BulletPhysicManager3D());
        }

        protected override void CreateScene()
        {

            var cameraEntity = new Entity("camera")
               .AddComponent(new Transform3D() { LocalPosition = new Vector3(0, 50, 300) })
               .AddComponent(new Camera3D()
               {
                   FieldOfViewAxis = FieldOfViewAxis.Horizontal,
               }
               ).AddComponent(new FreeCamera3D());

            // Create a new light entity.
            Entity pointLightEntity = new Entity()
                .AddComponent(new Transform3D() { LocalPosition=new Vector3(0,0,0)})
                .AddComponent(new DirectionalLight()
                {
                    Intensity = 3,
                });

            var assetsService = Application.Current.Container.Resolve<AssetsService>();



            //Loading model
            Model tagwayeModel = assetsService.Load<Model>(EvergineContent.Models.Scene_gltf);

            //making model as an entity
            Entity Tagwaye = tagwayeModel.InstantiateModelHierarchy(assetsService);



            
            
            //Adding entity to scene


           
            //Add the camera entity to the entity manager
            this.Managers.EntityManager.Add(cameraEntity);

            // Add the light entity to the entity manager.
            this.Managers.EntityManager.Add(pointLightEntity);

            //Add the tagwaye model
            this.Managers.EntityManager.Add(Tagwaye);

        }
    }
}