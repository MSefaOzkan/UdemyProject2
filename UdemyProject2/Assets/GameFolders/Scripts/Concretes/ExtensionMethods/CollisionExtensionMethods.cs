﻿using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Combats;
using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.ExtensionMethods
{
    public static class CollisionExtensionMethods
    {
        public static bool WasHitLeftOrRightSide(this Collision2D collision)
        {
            return collision.contacts[0].normal.x > 0.6f || collision.contacts[0].normal.x < -0.6f;
        }

        public static bool WasHitBottomSide(this Collision2D collision)
        {
            return collision.contacts[0].normal.y < -0.6f;
        }

        public static bool WasHitTopSide(this Collision2D collision)
        {
            return collision.contacts[0].normal.y > 0.6f;
        }

        public static bool WasHitPlayer(this Collision2D collision)
        {
            return collision.collider.GetComponent<PlayerController>() != null;
        }

        public static bool WasHitEnemy(this Collision2D collision)
        {
            return collision.collider.GetComponent<EnemyController>() != null;
        }

        public static Health ObjectHasHealth(this Collision2D collision)
        {
            Health health = collision.collider.GetComponent<Health>();

            if (health != null)
            {
                return health;
            }
            return null;
        }
    }
}

