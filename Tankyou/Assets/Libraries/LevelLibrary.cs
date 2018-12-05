using Assets.Controllers;
using Assets.UnityEditor;
using Assets.Levels;
using Assets.Levels.Entities;
using Assets.Levels.Entities.EntityTypes;
using Assets.Levels.Rooms;
using Assets.Levels.Rooms.SpriteLayers;
using Assets.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Libraries
{
    public class LevelLibrary : ILibrary<LevelName, Level>
    {
        private Dictionary<LevelName, Level> _levels;

        public void Init(PropContents propContents)
        {
            var entityFactory = new EntityFactory(propContents);
            var sprLib = propContents._libraryContainer.SpriteLibrary;

            var gl = propContents._libraryContainer.GameObjectLibrary;
            var mm = new MonoMapper(new EntityFactory(propContents));

            _levels = new Dictionary<LevelName, Level>()
            {
                {LevelName.Park,
                    new Level
                    {
                        Name = "The Park",
                        Rooms = new Dictionary<int, Room>()
                        {
                            {0, new Room()
                                {
                                    EnterDelegate = (Transition transition, Session session) =>
                                    {
                                        Debug.Log(transition);
                                    },
                                    
                                    
                                }
                                .MapFromMono(gl.Get("forest0").GetComponent<M_Room>(), mm)
                            },

                            {1, new Room()
                                {
                                    EnterDelegate = (Transition transition, Session session) =>
                                    {
                                        Debug.Log(transition);
                                    },


                                }
                                .MapFromMono(gl.Get("room0").GetComponent<M_Room>(), mm)
                            }
                        },
                        Transitions = new Dictionary<Transition, int>
                        {
                            {Transition.Default, 0},
                        }
                    }
                },


            };

        }

        public Level Get(LevelName name)
        {
            return _levels[name];
        }
    }
}
